﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using DichMusicHelper;

namespace MusicFromVKWalls
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

            string wallId = GetWallID(urlBox.Text);

            List<AudioInfo> temp = GetAudioList(wallId);

            foreach (AudioInfo song in temp)
            {
                list.Add(song);
                audioListBox.Items.Add(song.Artist + " - " + song.Title, true);
            }

            StatusLabel.Text = temp.Count == 0 ? "Не удалось загрузить композиции" : "";

            getAudioListButton.Enabled = true;
            urlBox.Text = "";
        }

        private string GetWallID(string urlString)
        {
            if (!urlString.Contains("wall"))
                return "";

            string tmp = urlString.Substring(urlString.IndexOf("wall") + 4);

            var wallId = new StringBuilder();
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
            var audioList = new List<AudioInfo>();

            string url = @"https://api.vk.com/method/wall.getById.xml?posts=" +
                         postID +
                         "&extended=1&copy_history_depth=1&v=5.14";
            try
            {                
                                                
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);

                var settings = new AppSettings();

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
                    var info = new AudioInfo();

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
            var settings = new AppSettings();            

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

            EnableComponents(false);

            myBackgroundWorker.RunWorkerAsync();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void proxyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var proxyForm = new ProxyForm();
            proxyForm.ShowDialog();
        }

        private void myBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            using (var client = new WebClient())
            {
                CheckForIllegalCrossThreadCalls = false;

                var settings = new AppSettings();

                if (settings.ProxySettings.UseProxy)
                {
                    client.Proxy = settings.ProxySettings.GetWebProxy();
                }

                var manualReset = new ManualResetEvent(false);
                var task = new CurrentTask();
               
                client.DownloadProgressChanged += delegate(object send, DownloadProgressChangedEventArgs ea)
                {
                    songPersentStatus.Text = ea.ProgressPercentage + "% ";
                    songProgress.Value = ea.ProgressPercentage;                    
                };

                client.DownloadFileCompleted += delegate(object sende, System.ComponentModel.AsyncCompletedEventArgs ea)
                {
                    manualReset.Set();
                };

                int progress = 0;                
                string path = settings.PathSettings.Path;

                for (int audioIindex = 0; audioIindex < audioListBox.Items.Count; audioIindex++)
                {
                    if (!audioListBox.GetItemChecked(audioIindex))                    
                        continue;                    

                    if (settings.PathSettings.CreateFolder)
                    {
                        path = settings.PathSettings.Path + @"\" + list[audioIindex].Artist;

                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                    }

                    progress = 100 * audioIindex / audioListBox.Items.Count;

                    task.Name = list[audioIindex].Artist + " - " + list[audioIindex].Title;
                    task.Index = audioIindex;

                    string fileName = path + @"\" + task.Name + ".mp3";

                    if (File.Exists(fileName))                    
                        continue;                    

                    myBackgroundWorker.ReportProgress(progress, task);

                    try
                    {
                        manualReset.Reset();
                        client.DownloadFileAsync(new Uri(list[audioIindex].Path), path + @"\" + task.Name + ".mp3");
                        manualReset.WaitOne();

                    }
                    catch (Exception)
                    {
                        StatusLabel.Text = "Ошибка при загрузке композиций";
                        EnableComponents(true);
                        return;
                    }

                    Thread.Sleep(200);
                }

                task.Name = "Готово";

                SetCheckedAudioList(false);
                EnableComponents(true);

                myBackgroundWorker.ReportProgress(100, task);
            }
        }
        
        private void myBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            StatusLabel.Text = ((CurrentTask)e.UserState).Name;
            StatusProgress.Value = e.ProgressPercentage > 100 ? 100 : e.ProgressPercentage;
            persentStatus.Text = e.ProgressPercentage + "% ";
        }

        private void pathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settingForm = new PathSettingForm();
            settingForm.ShowDialog(this);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var about = new AboutForm();
            about.ShowDialog(this);
        }

        private void selectAllStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCheckedAudioList(true);
        }

        private void selectNoAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCheckedAudioList(false);
        }

        private void clearListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            audioListBox.Items.Clear();
            list.Clear();
        }

        private void EnableComponents(bool enabled)
        {
            getAudioListButton.Enabled = enabled;
            audioListBox.Enabled = enabled;
            downloadButton.Enabled = enabled;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            persentStatus.Text = "";
            songPersentStatus.Text = "";
            StatusLabel.Text = "";
        }

        private void SetCheckedAudioList(bool check)
        {
            for (int audioIindex = 0; audioIindex < audioListBox.Items.Count; audioIindex++)
            {
                audioListBox.SetItemChecked(audioIindex, check);
            }
        }
    }
}
