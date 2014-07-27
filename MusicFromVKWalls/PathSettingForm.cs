using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DichMusicHelper
{
    public partial class PathSettingForm : Form
    {
        public PathSettingForm()
        {
            InitializeComponent();
        }

        private void brouseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowNewFolderButton = true;
            
            if (Directory.Exists(pathTextBox.Text))
            {
                dialog.SelectedPath = pathTextBox.Text;
            }
            dialog.ShowDialog(this);

            if (dialog.SelectedPath != "")
            {
                pathTextBox.Text = dialog.SelectedPath;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string settingsFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\DichMusicHelperPathSettings.xml";

            using (System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(settingsFile, System.Text.Encoding.Unicode))
            {                         
                writer.WriteStartElement("PathSettings");
                writer.WriteAttributeString("Path", pathTextBox.Text);
                writer.WriteAttributeString("CreateFolder", createFolderBox.Checked.ToString());
                writer.WriteEndElement();                
                writer.Close();
            }

            this.Close();
        }

        private void PathSettingForm_Load(object sender, EventArgs e)
        {
            AppSettings settings = new AppSettings();
            
            pathTextBox.Text = settings.PathSettings.Path;
            createFolderBox.Checked = settings.PathSettings.CreateFolder;
        }
    }
}
