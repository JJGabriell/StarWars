using Newtonsoft.Json;
using StarWars.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace StarWars.Services
{
    public class StarWarsService : IWebHelper
    {
        public virtual WebRequest GetRequest(string url)
        {
            return WebRequest.Create(url);
        }

        public virtual WebResponse GetResponse(WebRequest request)
        {
            return request.GetResponse();
        }
    }
}