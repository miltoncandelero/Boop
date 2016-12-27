using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boop
{
    partial class InfoBox : Form
    {
        public InfoBox()
        {
            InitializeComponent();
        }



        private void InfoBox_Load(object sender, EventArgs e)
        {
            new Task(LoadContributors).Start();
        }

        private void LoadContributors()
        {
            try
            {
            HttpWebRequest HttpRequestObj = (HttpWebRequest)HttpWebRequest.Create(@"https://api.github.com/repos/miltoncandelero/Boop/contributors");
            HttpRequestObj.Credentials = CredentialCache.DefaultCredentials;
            HttpRequestObj.ContentType = "application/json";
            HttpRequestObj.Method = "GET";
            HttpRequestObj.Accept = "application/json";
            HttpRequestObj.UserAgent = "Boop"; // NEEDS SOMETHING WRITTEN!
            HttpWebResponse response = (HttpWebResponse)HttpRequestObj.GetResponse();
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();
            

            JArray a = JArray.Parse(content);


            this.Invoke((MethodInvoker)delegate
            {
                lvContributors.Items.Clear();
                foreach (JObject o in a.Children<JObject>())
                {
                    lvContributors.Items.Add((string)o["login"]);
                }
            });

            }
            catch (Exception)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    //shrink all
                    this.Height = 174;
                });
            }

        }

        private void lvContributors_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            //Keep the width not changed.
            e.NewWidth = ((ListView)sender).Columns[e.ColumnIndex].Width;
            //Cancel the event.
            e.Cancel = true;
        }

        private void lvContributors_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Pls no touching the snek list.
            lvContributors.SelectedIndices.Clear();
        }

        private void lvContributors_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Red, e.Bounds);
            e.DrawText();
        }

    }
}
