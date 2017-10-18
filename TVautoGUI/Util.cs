using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace TVautoGUI
{
    class Util
    {
        static string showFilePath = System.Reflection.Assembly.GetEntryAssembly().Location.Replace("TVautoGUI.exe", "") + "shows.txt";
        private static HtmlDocument airdatesHtmlDocument;
        public static DataTable GetShowDataTable()
        {
            DataTable shows = new DataTable();
            shows.Columns.Add("Name", typeof(string));
            shows.Columns.Add("AirDay", typeof(string));
            shows.Columns.Add("LastEpDownload", typeof(string));

            if (!ShowFileExist())
                MessageBox.Show("There's no shows file!" + Environment.NewLine + "A new one will be created to add shows.",
                    "Note!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                foreach (string line in File.ReadAllLines(showFilePath))
                {
                    string[] showData = line.Split(',').ToArray();
                    DataRow showRow = shows.NewRow();

                    showRow["Name"] = showData[0];
                    showRow["AirDay"] = showData[1];
                    showRow["LastEpDownload"] = showData[2];

                    shows.Rows.Add(showRow);
                }
            }

            return shows;
        }

        public static bool ShowFileExist()
        {
            return File.Exists(showFilePath);
        }

        public static bool CheckShowExists(string show)
        {
            HtmlDocument adHtmlDocument = airdatesHtmlDocument ?? GetAirdatesDoc();

            var node = adHtmlDocument.DocumentNode.SelectNodes("/html/body");

            return node.Any(x => x.InnerHtml.ToUpper().Contains(show.ToUpper()));
        }

        public static bool AddShow(string show)
        {
            File.AppendAllText(showFilePath, Environment.NewLine + show + ", , ");
            return true;
        }

        private static HtmlDocument GetAirdatesDoc()
        {
            if (airdatesHtmlDocument == null)
            {
                var url = "http://www.airdates.tv/";
                var data = new MyWebClient().DownloadString(url);
                var doc = new HtmlDocument();
                doc.LoadHtml(data);

                airdatesHtmlDocument = doc;

                return doc;
            }
            else
            {
                return airdatesHtmlDocument;
            }
        }

        public static void RunProcessForAllShows(StreamWriter file = null)
        {
            DateTime today = DateTime.Now.AddDays(-1);
            string sToday = today.DayOfWeek.ToString().Substring(0, 3) + ", " + (today.Day < 10? "0": "") + today.Day + ". " +
            today.ToString("MMMM").Substring(0, 3);

            HtmlDocument adHtmlDocument = airdatesHtmlDocument ?? GetAirdatesDoc();

            var node = adHtmlDocument.DocumentNode.SelectNodes("/html/body/div/div/div");

            var todaysShows = node.FirstOrDefault(x => x.InnerText.Contains(sToday));

            foreach (DataRow row in GetShowDataTable().Rows)
            {
                DataRow r = row;
                string name = row["Name"].ToString();
                var showEp =
                    todaysShows.ChildNodes.FirstOrDefault(x => x.Name.Equals("div") && x.InnerHtml.ToUpper().Contains(row["Name"].ToString().ToUpper()));

                if (showEp != null)
                {
                    string showEpi = showEp.InnerText.Replace("\t", String.Empty).Replace("\n", String.Empty);

                    string showEp720p = showEpi + " 720p";

                    string showEpForUrl = showEp720p.Replace(" ", "%20");

                    try
                    {
                        DataTable magnetsList = GetMagnetsFromTPB(showEpForUrl);

                        if(magnetsList.Rows.Count > 0)
                            Process.Start(magnetsList.Rows[0]["Magnet Link"].ToString());

                        if (file != null)
                            file.WriteLine("Downloaded " + showEp720p);
                    }
                    catch(Exception ex)
                    { }
                }
            }
        }

        public static DataTable GetMagnetsFromTPB(string showEpForUrl)
        {
            DataTable magnetsTable = new DataTable();
            magnetsTable.Columns.Add("File Name");
            magnetsTable.Columns.Add("File Size");
            magnetsTable.Columns.Add("Magnet Link");

            string thepiratebayUrl = "https://thepiratebay.org/search/" + showEpForUrl + "/0/99/0";
            var tpbData = new MyWebClient().DownloadString(thepiratebayUrl);
            var tpbDoc = new HtmlDocument();
            tpbDoc.LoadHtml(tpbData);

            var allNoed = tpbDoc.DocumentNode.SelectNodes("/html/body/div/div/div/table/tr/td");
            var fonts = allNoed.Descendants("font").ToList();

            var decs = allNoed.Descendants("a");
            var tpbNode =
                decs.Select(x => x.Attributes["href"].Value)
                    .Where(z => z.StartsWith("ma") || z.StartsWith("/to"))
                    .ToList();

            int i = 0; 
            while (i < tpbNode.Count)
            { 
                DataRow newRow = magnetsTable.NewRow();
                newRow["File Name"] = tpbNode[i++].Split('/').Last();
                newRow["Magnet Link"] = tpbNode[i++];
                newRow["File Size"] = fonts[(i / 2) - 1].InnerText.Split(',')
                    .Where(x => x.StartsWith(" Size")).First().Replace("&nbsp;", " ").Replace(" Size ", "");
                //sample font.innerText string 'Uploaded Y-day&nbsp;11:27, Size 822.28&nbsp;MiB, ULed by hunch99'

                magnetsTable.Rows.Add(newRow);
            }

            return magnetsTable;
        }


        public static async Task<TVmazeShowEpData> GetShowEpisodesData(string showName)
        {
            var client = new HttpClient();

            var sb = new StringBuilder();

            sb.Append("http://api.tvmaze.com/singlesearch/shows?q=");
            sb.Append(showName.Trim().Replace(" ", "%20"));
            sb.Append("&embed=episodes");

            var uri = new Uri(sb.ToString());
            var response = await client.GetStringAsync(uri);
            
            TVmazeShowEpData showData = JsonConvert.DeserializeObject<TVmazeShowEpData>(response);
            
            return showData;
        }

        public static async Task<Tuple<string, string>> GetLastSeasonAndEpisode(string showName)
        {
            TVmazeShowEpData data = await GetShowEpisodesData(showName);
            var seasonAndEp = data._embedded.episodes
                .Where(x => x.airstamp < DateTime.Now).OrderByDescending(s => s.airstamp).First();

            string season = (seasonAndEp.season < 10 ? 0 + "": "") + seasonAndEp.season;
            string episode = (seasonAndEp.number < 10 ? 0 + "" : "") + seasonAndEp.number;


            return new Tuple<string, string>(season, episode);
        }
    }
}
