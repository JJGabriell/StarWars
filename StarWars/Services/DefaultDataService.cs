using StarWars.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace StarWars.Services
{
    public class DefaultDataService : IDataService
    {
        private IWebHelper webHelper;

        public DefaultDataService(IWebHelper webHelper)
        {
            this.webHelper = webHelper;
        }

        public string GetDataResult(string url)
        {
            WebRequest request = webHelper.GetRequest(url);
            try
            {
                WebResponse response = webHelper.GetResponse(request);
                string json = string.Empty;
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    json = reader.ReadToEnd();
                }
                return json;
            }
            catch (WebException)
            {
                return null;
            }
        }
    }

}