using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetOpenAuth.AspNet.Clients;
using Politico.Models;

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
            if (picture.Length > 0)
                Session["picture"] = picture;
            else
                Session["picture"] = "/images/Application/placeholder.png";

            return Json(new
            {
                RedirectUrl = Url.Action("Home", "Home")
            });
        }

        public ActionResult Login(string ID)
        {
            Session["Constituency"] = ID;

            DotNetOpenAuth.AspNet.Clients.TwitterClient client = new TwitterClient("KcYMu5YzGllcA5tNfSWQ", "PGcd4ZlTxd3eAj4CFiFXEyHE3tnONGz2Ihf11KJTSA");

            UrlHelper helper = new UrlHelper(this.ControllerContext.RequestContext);
            var result = helper.Action("Callback", "Home", null, "http");

            client.RequestAuthentication(this.HttpContext, new Uri(result));

            return new EmptyResult();
        }

        public ActionResult Callback()
        {
            DotNetOpenAuth.AspNet.Clients.TwitterClient client = new TwitterClient("KcYMu5YzGllcA5tNfSWQ", "PGcd4ZlTxd3eAj4CFiFXEyHE3tnONGz2Ihf11KJTSA");

            var result = client.VerifyAuthentication(this.HttpContext);

            CacheClear();

            Session["email"] = "";
            Session["name"] = result.UserName;
            Session["picture"] = "/images/Application/placeholder.png";

            if (Session["email"] != null)
            {
                ViewBag.Constituency = Session["Constituency"];
                ViewBag.Name = Session["name"];
                ViewBag.Picture = Session["picture"];

                return View("Home", "_HomePageLayout");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public JsonResult LoadMpProfile(string constituency)
        {
            PoliticoEntities entity = new PoliticoEntities();
            var result = entity.FindMPOfConstituency(constituency).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Logout()
        {
            Session["Constituency"] = null;
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
