using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        //public static string[] scrapForShow(string show)
        //{
        //    DateTime today = DateTime.Now;
        //    string sToday = today.DayOfWeek.ToString().Substring(0, 3) + ", " + today.Day + ". " +
        //    today.ToString("MMMM").Substring(0, 3);

        //    var url = "http://www.airdates.tv/";
        //    var data = new MyWebClient().DownloadString(url);
        //    var doc = new HtmlDocument();
        //    doc.LoadHtml(data);

        //    var node = doc.DocumentNode.SelectNodes("/html/body/div/div/div");

        //    var todaysShows = node.FirstOrDefault(x => x.InnerText.Contains("Sat, 30. Sep"));

        //    string showEpisode = todaysShows.ChildNodes.FirstOrDefault(x => x.Name.Equals("div") && x.InnerHtml.Contains(show)).InnerText.Replace("\t", String.Empty).Replace("\n", String.Empty);

        //    //Console.WriteLine(showEpisode);
        //    //Henry Danger
        //    string showEp720p = showEpisode + " 720p";

        //    string showEpForUrl = showEp720p.Replace(" ", "%20");

        //    string thepiratebayUrl = "https://thepiratebay.se/search/" + showEpForUrl + "/0/99/0";
        //    var tpbData = new MyWebClient().DownloadString(thepiratebayUrl);
        //    var tpbDoc = new HtmlDocument();
        //    tpbDoc.LoadHtml(tpbData);

        //    var tpbNode = tpbDoc.DocumentNode.SelectNodes("/html/body/div/div");

        //    var magnet = tpbNode.FirstOrDefault(x => x.InnerHtml.Contains("a href=\"magnet:")).InnerHtml.Split('<').Where(t => t.StartsWith("a href=\"magnet")).Select(r => r.Substring(8, r.Length - 8));//use index of to get till first "
        //    //var mag = magnet.First();

        //    foreach (string magn in magnet)
        //    {
        //        string magt = magn.Substring(0, magn.IndexOf("\""));

        //        Process.Start(magt);
        //    }

        //    return magnet.ToArray();
        //}

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

        public static void RunProcessForAllShows()
        {
            DateTime today = DateTime.Now;
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

            string thepiratebayUrl = "https://thepiratebay.se/search/" + showEpForUrl + "/0/99/0";
            var tpbData = new MyWebClient().DownloadString(thepiratebayUrl);
            var tpbDoc = new HtmlDocument();
            tpbDoc.LoadHtml(tpbData);

            ///table/tr/td/div
            /// //var tpbNode = tpbDoc.DocumentNode.SelectNodes("/html/body/div/div/div/table/tr/td").Descendants("a").Select(x => x.Attributes["href"].Value).Where(z => z.StartsWith("ma") || z.StartsWith("/to")).ToList();
            var allNoed = tpbDoc.DocumentNode.SelectNodes("/html/body/div/div/div/table/tr/td");
            var fonts = allNoed.Descendants("font").ToList();

            var decs = allNoed.Descendants("a");
            var tpbNode =
                decs.Select(x => x.Attributes["href"].Value)
                    .Where(z => z.StartsWith("ma") || z.StartsWith("/to"))
                    .ToList();
            //var magnets = tpbNode.FirstOrDefault(x => x.InnerHtml.Contains("a href=\"magnet:"))
            //    .InnerHtml.Split('<').Where(t => t.StartsWith("a href=\"magnet"))
            //    .Select(r => r.Substring(8, r.Length - 8));

            int i = 0; 
            while (i < tpbNode.Count)
            { 
                //figure out how to parse the data to get the file name and link, add to table.
                DataRow newRow = magnetsTable.NewRow();
                newRow["File Name"] = tpbNode[i++].Split('/').Last();
                newRow["Magnet Link"] = tpbNode[i++];
                newRow["File Size"] = fonts[(i / 2) - 1].InnerText.Split(',')
                    .Where(x => x.StartsWith(" Size")).First().Replace("&nbsp;", " ").Replace(" Size ", "");
                //sample font.innerText string 'Uploaded Y-day&nbsp;11:27, Size 822.28&nbsp;MiB, ULed by hunch99'

                magnetsTable.Rows.Add(newRow);
                //magnetsTable.Add(magnet.Substring(0, magnet.IndexOf("\"")));
            }

            return magnetsTable;
        }
    }
}
