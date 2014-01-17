using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Politico.Models;
using System.IO;

namespace Politico.Controllers
{
    public class MPController : Controller
    {
        private MPContext db = new MPContext();

        //
        // GET: /MP/

        public ActionResult Index()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var mps = db.MPs.Include(m => m.Constituency).Include(m => m.Party);
                return View(mps.ToList());
            }                 
        }

        //
        // GET: /MP/Details/5

        public ActionResult Details(long id = 0)
        {
            MP mp = db.MPs.Find(id);
            if (mp == null)
            {
                return HttpNotFound();
            }
            return View(mp);
        }

        //
        // GET: /MP/Create

        public ActionResult Create()
        {
            ViewBag.constituencyID = new SelectList(db.Constituencies, "ID", "title");
            ViewBag.partyID = new SelectList(db.Parties, "ID", "title");
            return View();
        }

        //
        // POST: /MP/Create

        [HttpPost]
        public ActionResult Create(MP mp, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file == null)
                {
                    ModelState.AddModelError("File", "Please upload your file");
                }
                else if (file.ContentLength > 0)
                {
                    int MaxContentLength = 1024 * 1024 * 3; //3 MB
                    string[] AllowedFileExtensions = new string[] { ".jpg", ".gif", ".png", ".pdf" };

                    if (!AllowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
                    {
                        ModelState.AddModelError("File", "Please file of type: " + string.Join(", ", AllowedFileExtensions));
                    }

                    else if (file.ContentLength > MaxContentLength)
                    {
                        ModelState.AddModelError("File", "Your file is too large, maximum allowed size is: " + MaxContentLength + " MB");
                    }
                    else
                    {
                        //TO:DO
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Images/Application/MP/"), fileName);
                        file.SaveAs(path);
                        mp.image = "~/Images/Application/MP/" + fileName; ;
                        ModelState.Clear();
                    }
                }
                db.MPs.Add(mp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.constituencyID = new SelectList(db.Constituencies, "ID", "title", mp.constituencyID);
            ViewBag.partyID = new SelectList(db.Parties, "ID", "title", mp.partyID);
            return View(mp);
        }

        //
        // GET: /MP/Edit/5

        public ActionResult Edit(long id = 0)
        {
            MP mp = db.MPs.Find(id);
            if (mp == null)
            {
                return HttpNotFound();
            }
            ViewBag.constituencyID = new SelectList(db.Constituencies, "ID", "title", mp.constituencyID);
            ViewBag.partyID = new SelectList(db.Parties, "ID", "title", mp.partyID);
            return View(mp);
        }

        //
        // POST: /MP/Edit/5

        [HttpPost]
        public ActionResult Edit(MP mp, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file == null)
                {
                    ModelState.AddModelError("File", "Please upload your file");
                }
                else if (file.ContentLength > 0)
                {
                    int MaxContentLength = 1024 * 1024 * 3; //3 MB
                    string[] AllowedFileExtensions = new string[] { ".jpg", ".gif", ".png", ".pdf" };

                    if (!AllowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
                    {
                        ModelState.AddModelError("File", "Please file of type: " + string.Join(", ", AllowedFileExtensions));
                    }

                    else if (file.ContentLength > MaxContentLength)
                    {
                        ModelState.AddModelError("File", "Your file is too large, maximum allowed size is: " + MaxContentLength + " MB");
                    }
                    else
                    {
                        //TO:DO
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Images/Application/MP/"), fileName);
                        file.SaveAs(path);
                        mp.image = "~/Images/Application/MP/" + fileName; ;
                        ModelState.Clear();
                    }
                }
                db.Entry(mp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.constituencyID = new SelectList(db.Constituencies, "ID", "title", mp.constituencyID);
            ViewBag.partyID = new SelectList(db.Parties, "ID", "title", mp.partyID);
            return View(mp);
        }

        //
        // GET: /MP/Delete/5

        public ActionResult Delete(long id = 0)
        {
            MP mp = db.MPs.Find(id);
            if (mp == null)
            {
                return HttpNotFound();
            }
            return View(mp);
        }

        //
        // POST: /MP/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            MP mp = db.MPs.Find(id);
            db.MPs.Remove(mp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}