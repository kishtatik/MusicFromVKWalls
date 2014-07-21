using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

namespace DichMusicHelper
{
    public partial class MainForm : Form
    {
        private List<AudioInfo> list;

        public MainForm()
        {
            InitializeComponent();

            list = new List<AudioInfo>();
        }

        private void button1_Click(object sender, EventArgs e)
        {                       
            if(!urlBox.Text.Contains("wall")) 
                return;

            getAudioListButton.Enabled = false;

            StatusLabel.Text = "Получение списка композиций...";

            string wallID = GetWallID(urlBox.Text);

            List<AudioInfo> temp = GetAudioList(wallID);

            foreach (AudioInfo tmp in temp)
            {
                list.Add(tmp);
            }

            //audioListBox.Items.Clear();
            
            if (temp.Count == 0)
            {
                StatusLabel.Text = "Не удалось загрузить композиции";
            }
            else
            {
                StatusLabel.Text = "";
            }

            foreach (AudioInfo song in temp)
            {
                audioListBox.Items.Add(song.Artist + " - " + song.Title, true);
            }

            getAudioListButton.Enabled = true;
            urlBox.Text = "";
        }

        private string GetWallID(string urlString)
        {
            if (!urlBox.Text.Contains("wall"))
                return "";

            string tmp = urlBox.Text.Substring(urlBox.Text.IndexOf("wall") + 4);

            StringBuilder wallId = new StringBuilder();
            foreach (char ch in tmp)
            {
                if ((Char.IsDigit(ch)) || ch == '-' || ch == '_')
                {
                    wallId.Append(ch);
                }
                else
                {
                    break;
                }
            }

            return wallId.ToString();
        }

        private List<AudioInfo> GetAudioList(string postID)
        {
            List<AudioInfo> audioList = new List<AudioInfo>();

            string url = @"https://api.vk.com/method/wall.getById.xml?posts=" +
                         postID +
                         "&extended=1&copy_history_depth=1&v=5.14";
            try
            {                
                                                
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);

                AppSettings settings = new AppSettings();

                if (settings.ProxySettings.UseProxy)
                {
                    req.Proxy = settings.ProxySettings.GetWebProxy();
                }
                
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();                

                string result = "";

                using (StreamReader stream = new StreamReader(resp.GetResponseStream()))
                {
                    result = stream.ReadToEnd();
                }
                                
                XElement root = XElement.Parse(result);

                var audio = (from e
                    in root.Descendants("audio")
                             select e).ToList();

                foreach (XElement element in audio)
                {
                    AudioInfo info = new AudioInfo();

                    info.Artist = ReplaceBadChars(element.Element("artist").Value);
                    info.Title = ReplaceBadChars(element.Element("title").Value);
                    info.Path = element.Element("url").Value;

                    audioList.Add(info);
                }                
            }
            catch (Exception e)
            {
                StatusLabel.Text = "Ошибка при получении композиций";
            }

            return audioList;
        }

        public string ReplaceBadChars(string val)
        {
            string result = val;

            foreach (char ch in Path.GetInvalidFileNameChars())
            {
                result = result.Replace(ch, '_');
            }

            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AppSettings settings = new AppSettings();

            if (!Directory.Exists(settings.PathSettings.Path))
            {
                MessageBox.Show("Укажите корректный путь сохранения файлов", "Внимание", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (audioListBox.CheckedItems.Count == 0)
            {
                return;
            }

            getAudioListButton.Enabled = false;
            audioListBox.Enabled = false;
            downloadButton.Enabled = false;

            myBackgroundWorker.RunWorkerAsync();
        }

        

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void proxyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProxyForm proxyForm = new ProxyForm();
            proxyForm.ShowDialog();
        }

        private void myBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            using (WebClient client = new WebClient())
            {                
                AppSettings settings = new AppSettings();

                if (settings.ProxySettings.UseProxy)
                {
                    client.Proxy = settings.ProxySettings.GetWebProxy();
                }

                CurrentTask task = new CurrentTask();

                int progress = 0;

                string currentArtist = "";
                string path = settings.PathSettings.Path;

                for (int audioIindex = 0; audioIindex < audioListBox.Items.Count; audioIindex++)
                {
                    if (!audioListBox.GetItemChecked(audioIindex))
                    {
                        continue;
                    }

                    if (settings.PathSettings.CreateFolder && currentArtist != list[audioIindex].Artist)
                    {
                        path = settings.PathSettings.Path + @"\" + list[audioIindex].Artist;

                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                    }

                    progress = 100 * audioIindex / audioListBox.CheckedItems.Count;

                    task.Name = list[audioIindex].Artist + " - " + list[audioIindex].Title;
                    task.Index = audioIindex;

                    string fileName = path + @"\" + task.Name + ".mp3";

                    if (File.Exists(fileName))
                    {
                        continue;
                    }

                    myBackgroundWorker.ReportProgress(progress, task);

                    try
                    {
                        client.DownloadFile(list[audioIindex].Path, path + @"\" + task.Name + ".mp3");
                    }
                    catch (Exception)
                    {
                        
                    }

                    Thread.Sleep(200);
                }

                task.Name = "Готово";

                myBackgroundWorker.ReportProgress(100, task);
            }
        }

        private void myBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            StatusLabel.Text = ((CurrentTask)e.UserState).Name;
            StatusProgress.Value = e.ProgressPercentage > 100 ? 100 : e.ProgressPercentage;

            if (e.ProgressPercentage == 100)
            {
                foreach (int audioIindex in audioListBox.CheckedIndices)
                {
                    audioListBox.SetItemChecked(audioIindex, false);
                }

                getAudioListButton.Enabled = true;
                audioListBox.Enabled = true;
                downloadButton.Enabled = true;
            }
        }

        private void pathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PathSettingForm settingForm = new PathSettingForm();
            settingForm.ShowDialog(this);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.ShowDialog(this);
        }

        private void selectAllStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int audioIindex = 0; audioIindex < audioListBox.Items.Count; audioIindex++)
            {
                audioListBox.SetItemChecked(audioIindex, true);
            }
        }

        private void selectNoAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int audioIindex = 0; audioIindex < audioListBox.Items.Count; audioIindex++)
            {
                audioListBox.SetItemChecked(audioIindex, false);
            }
        }

        private void clearListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            audioListBox.Items.Clear();
            list.Clear();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            audioListBox.Items.Clear();
            list.Clear();
        }
    }
}
