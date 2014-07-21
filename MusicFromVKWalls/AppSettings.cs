using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DichMusicHelper
{
    class AppSettings
    {

        public Proxy ProxySettings { get; set; }
        public PathSetting PathSettings { get; set; }
        public AppSettings()
        {            
            this.ProxySettings = new Proxy();
            this.PathSettings = new PathSetting();
            
            string proxySettingsFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\DichMusicHelperProxySettings.xml";
            string pathSettingsFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\DichMusicHelperPathSettings.xml";

            try
            {
                if (System.IO.File.Exists(proxySettingsFile))
                {
                    using (System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(proxySettingsFile))
                    {
                        while (reader.Read())
                        {
                            if (reader.Name == "ProxySettings")
                            {
                                this.ProxySettings.Server = reader[0];
                                this.ProxySettings.Port = reader[1];
                                this.ProxySettings.User = reader[2];
                                this.ProxySettings.Password = reader[3];
                                this.ProxySettings.UseProxy = Convert.ToBoolean(reader[4]);
                            }                           
                        }
                    }
                }

                if (System.IO.File.Exists(pathSettingsFile))
                {
                    using (System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(pathSettingsFile))
                    {
                        while (reader.Read())
                        {
                            if (reader.Name == "PathSettings")
                            {
                                this.PathSettings.Path = reader[0];
                                this.PathSettings.CreateFolder = Boolean.Parse(reader[1]);                                
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                
            }
        }
    }
}
