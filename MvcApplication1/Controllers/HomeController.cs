using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class HomeController : AsyncController
    {
        public ActionResult Index()
        {
            var html = new StringBuilder()
                .Append("<html><head><title>TestCallContext</title></head><body>")
                .AppendFormat("<h2>Home/Index on {0}</h2>", HostAndPort)
                .Append("<div>Make sure the debugger is attached and watch the Output -> Debug window for log messages</div>");

            new List<string> { "/Home/Long", "/Home/Long2" }.ForEach(link => html.AppendFormat("<div><a href='{0}{1}'>{1}</a></div>", HostAndPort, link));
            
            html.Append("</body></html>");

            return Content(html.ToString());
        }

        public ActionResult Long()
        {
            Thread.Sleep(2000);
            return Content("Long");
        }

        public async Task<ActionResult> Long2Async()
        {
            var resp = await HitLong();
            return Content("AsyncLong: " + resp);
        }

        public async Task<string> HitLong()
        {
            using (var http = new HttpClient())
            {
                var resp = await http.GetAsync(HostAndPort + "/Home/Long");
                return resp.Content.ReadAsStringAsync().Result;
            }
        }

        private string HostAndPort // e.g. http://localhost:56665
        {
            get { return Request.Url.GetLeftPart(UriPartial.Authority); }
        }
        
    }
}
