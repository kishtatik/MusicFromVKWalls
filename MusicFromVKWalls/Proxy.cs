using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace DichMusicHelper
{
    class Proxy
    {
        public string Server { get; set; }
        public string Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        public bool UseProxy { get; set;}

        public WebProxy GetWebProxy()
        {
            WebProxy proxy = new WebProxy();

            if (Server == "") 
                return proxy;

            string proxyString = Server + (Port != "" ? ":" + Port : "");

            proxy = new WebProxy(proxyString);

            if (User != "")
            {
                proxy.Credentials = new NetworkCredential(User, Password);
            }
            return proxy;
        }

    }
}
