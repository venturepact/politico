using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Politico.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {            
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
           
            return View("Index", "_LandingPageLayout");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Home(string key)
        {
            CacheClear();

            if (Session["email"] != null)
            {
                ViewBag.Constituency = key;
                ViewBag.Name = Session["name"].ToString();
                ViewBag.Picture = Session["picture"].ToString();

                return View("Home", "_HomePageLayout");                
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult SaveMember(string email, string name, string picture)
        {
            Session["email"] = email;
            Session["name"] = name;
            Session["picture"] = picture;
            
            return Json(new            
            {                
                RedirectUrl = Url.Action("Home", "Home")
            });
        }

        [HttpPost]
        public ActionResult Logout()
        {
            Session["email"] = null;
            Session["name"] = null;
            Session["picture"] = null;
                        
            return Json(new
            {
                RedirectUrl = Url.Action("Index", "Home")
            });
        }

        private void CacheClear()
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.AddHeader("pragma", "no-cache");
            Response.AddHeader("Cache-Control", "no-cache");
            Response.CacheControl = "no-cache";
            Response.Expires = -1;
            Response.ExpiresAbsolute = DateTime.Now.AddSeconds(-1);
            Response.Cache.SetNoStore();
        }
    }
}
