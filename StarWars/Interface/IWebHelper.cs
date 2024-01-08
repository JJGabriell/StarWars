using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Interface
{
    public interface IWebHelper
    {
        WebRequest GetRequest(string url);

        WebResponse GetResponse(WebRequest request);
    }
}
