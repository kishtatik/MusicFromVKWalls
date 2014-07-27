using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DichMusicHelper
{
    public partial class ProxyForm : Form
    {
        public ProxyForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string settingsFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\DichMusicHelperProxySettings.xml";

            using (System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(settingsFile, System.Text.Encoding.Unicode))
            {
                writer.WriteStartElement("ProxySettings");
                writer.WriteAttributeString("Server", serverBox.Text);
                writer.WriteAttributeString("Port", portBox.Text);
                writer.WriteAttributeString("Login", loginBox.Text);
                writer.WriteAttributeString("Password", passwordBox.Text);
                writer.WriteAttributeString("UseProxy", useProxyBox.Checked.ToString());
                writer.WriteEndElement();
                writer.Close();
            }           

            this.Close();
        }

        private void ProxyForm_Load(object sender, EventArgs e)
        {
            AppSettings settings = new AppSettings();

            useProxyBox.Checked = settings.ProxySettings.UseProxy;
            serverBox.Text = settings.ProxySettings.Server;
            portBox.Text = settings.ProxySettings.Port;
            loginBox.Text = settings.ProxySettings.User;
            passwordBox.Text = settings.ProxySettings.Password;

            SetComponentsEnabled(useProxyBox.Checked);
        }

        private void SetComponentsEnabled(bool Enabled)
        {
            serverBox.Enabled = Enabled;
            portBox.Enabled = Enabled;
            loginBox.Enabled = Enabled;
            passwordBox.Enabled = Enabled;
        }

        private void useProxyBox_CheckedChanged(object sender, EventArgs e)
        {
            SetComponentsEnabled(useProxyBox.Checked);
        }
    }
}
