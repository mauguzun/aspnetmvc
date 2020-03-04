using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public string GetAge()
        {
         
            var idnt = (ClaimsPrincipal)Thread.CurrentPrincipal;
            return idnt.Claims.Where(x => x.Type == "age").Select(x => x.Value).SingleOrDefault();
          
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}