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
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            const string path = @"https://money.yandex.ru/embed/donate.xml?account=410011028249686&quickpay=donate&payment-type-choice=on&default-sum=50&targets=%D0%91%D0%BB%D0%B0%D0%B3%D0%BE%D0%B4%D0%B0%D1%80%D0%BD%D0%BE%D1%81%D1%82%D1%8C+%D0%B0%D0%B2%D1%82%D0%BE%D1%80%D1%83&target-visibility=on&project-name=MusicFromVKWalls&project-site=&button-text=01";
            System.Diagnostics.Process.Start(path);
        }
    }
}
