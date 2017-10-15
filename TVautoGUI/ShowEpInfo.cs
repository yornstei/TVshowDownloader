using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TVautoGUI
{
    public partial class ShowEpInfo : Form
    {
        public int curShowIndex = 0;
        public TVmazeShowEpData data;
        public ShowEpInfo(TVmazeShowEpData showData)
        {
            InitializeComponent();
            data = showData;

            BindShow();
            BindEpisode(true);
        }

        private void BindEpisode(bool lastEp = false)
        {
            Episode currEpisode;
            if (lastEp)
                currEpisode =
                    data._embedded.episodes.Where(x => x.airstamp > DateTime.Now)
                        .OrderByDescending(x => x.airstamp)
                        .First();
            else
                currEpisode = data._embedded.episodes[curShowIndex];

            lbl_ep_name.Text = currEpisode.name;
            lbl_season.Text = currEpisode.season.ToString();
            lbl_ep_num.Text = currEpisode.number.ToString();
            lbl_ep_airdatetime.Text = currEpisode.airstamp.ToString("G");
            lbl_ep_summary.Text = currEpisode.summary;

            if(currEpisode.image != null && currEpisode.image.medium != null)
                picbox_ep.Image = GetImageFromUrl(currEpisode.image.medium);
        }

        private void BindShow()
        {
            lbl_name.Text = data.name;
            lbl_type.Text = data.type;
            lbl_lang.Text = data.language;
            lbl_genres.Text = string.Join(",", data.genres);
            lbl_status.Text = data.status;
            lbl_runtime.Text = data.runtime.ToString();
            lbl_premiered.Text = data.premiered;
            lbl_officialsite.Text = data.officialSite;
            lbl_schedule.Text = data.schedule.time + " " + string.Join(",", data.schedule.days) + " " +
                                data.network.country.timezone;
            lbl_rating.Text = data.rating.average.ToString();
            lbl_summary.Text = data.summary;

            picbox_show.Image = GetImageFromUrl(data.image.medium);
        }

        private Bitmap GetImageFromUrl(string url)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(url);
            Bitmap bitmap;
            bitmap = new Bitmap(stream);

            stream.Flush();
            stream.Close();
            client.Dispose();

            return bitmap;
        }

        private void btn_prev_ep_Click(object sender, EventArgs e)
        {
            curShowIndex--;
            if (curShowIndex < 0)
                curShowIndex = data._embedded.episodes.Length - 1;
            BindEpisode();
        }

        private void btn_next_ep_Click(object sender, EventArgs e)
        {
            curShowIndex++;
            if (curShowIndex == data._embedded.episodes.Length)
                curShowIndex = 0;
            BindEpisode();
        }

        private void btn_download_Click(object sender, EventArgs e)
        {
            string xForDownload = "";

            if (chk_season.Checked)
            {
                xForDownload = data.name + " season " + data._embedded.episodes[curShowIndex].season;
            }
            else
            {
                string season = (int.Parse(lbl_season.Text) < 10 ? 0 + "" : "") + int.Parse(lbl_season.Text);
                string episode = (int.Parse(lbl_ep_num.Text) < 10 ? 0 + "" : "") + int.Parse(lbl_ep_num.Text);

                xForDownload = data.name + " S" + season + "E" + episode;
            }

            if (chk_720p.Checked)
                xForDownload += " 720p";

            string xForUrl = xForDownload.Trim().Replace(" ", "%20");

            DataTable links = Util.GetMagnetsFromTPB(xForUrl);

            if (links.Rows.Count > 0)
            {
                MagnetLinks formMagnetLinks = new MagnetLinks(links, xForDownload);
                formMagnetLinks.Show();
            }
            else
            {
                MessageBox.Show("Your search returned no results!", "Message",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Llbl_imdb_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.imdb.com/title/" + data.externals.imdb + "/");
        }
    }
}
