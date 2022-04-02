using Models;
using Newtonsoft.Json;
using SaatSatış.DAL;
using SaatSatış.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SaatSatış.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Services
        public ActionResult Index()
        {           
            HttpClient client = new HttpClient();
            string data = client.GetStringAsync("http://localhost:62064/api/WatchesService").Result;
            List<Watch> list = JsonConvert.DeserializeObject<List<Watch>>(data);
            WatchContext db = new WatchContext();
            DbSet<Watch> watches = db.Set<Watch>();
            watches.AddRange(list);
            watches.Include("Brand").Include("CaseShape").Include("GlassType").Include("StrapType").Include("Technology").Include("Gender").Include("Color");

            return View(watches);
        }
    }
}