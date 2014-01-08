using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Politico.Models;

namespace Politico.Controllers
{
    public class MPController : Controller
    {
        private MPContext db = new MPContext();

        //
        // GET: /MP/

        public ActionResult Index()
        {
            var mps = db.MPs.Include(m => m.Constituency).Include(m => m.Party);
            return View(mps.ToList());
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
        public ActionResult Create(MP mp)
        {
            if (ModelState.IsValid)
            {
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
        public ActionResult Edit(MP mp)
        {
            if (ModelState.IsValid)
            {
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