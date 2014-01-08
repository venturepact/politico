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
    public class ConstituencyController : Controller
    {
        private ConstituencyContext db = new ConstituencyContext();

        //
        // GET: /Constituency/

        public ActionResult Index()
        {
            var constituencies = db.Constituencies.Include(c => c.Party).Include(c => c.State);
            return View(constituencies.ToList());
        }

        //
        // GET: /Constituency/Details/5

        public ActionResult Details(int id = 0)
        {
            Constituency constituency = db.Constituencies.Find(id);
            if (constituency == null)
            {
                return HttpNotFound();
            }
            return View(constituency);
        }

        //
        // GET: /Constituency/Create

        public ActionResult Create()
        {
            ViewBag.partyID = new SelectList(db.Parties, "ID", "title");
            ViewBag.stateID = new SelectList(db.States, "ID", "title");
            return View();
        }

        //
        // POST: /Constituency/Create

        [HttpPost]
        public ActionResult Create(Constituency constituency)
        {
            if (ModelState.IsValid)
            {
                db.Constituencies.Add(constituency);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.partyID = new SelectList(db.Parties, "ID", "title", constituency.partyID);
            ViewBag.stateID = new SelectList(db.States, "ID", "title", constituency.stateID);
            return View(constituency);
        }

        //
        // GET: /Constituency/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Constituency constituency = db.Constituencies.Find(id);
            if (constituency == null)
            {
                return HttpNotFound();
            }
            ViewBag.partyID = new SelectList(db.Parties, "ID", "title", constituency.partyID);
            ViewBag.stateID = new SelectList(db.States, "ID", "title", constituency.stateID);
            return View(constituency);
        }

        //
        // POST: /Constituency/Edit/5

        [HttpPost]
        public ActionResult Edit(Constituency constituency)
        {
            if (ModelState.IsValid)
            {
                db.Entry(constituency).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.partyID = new SelectList(db.Parties, "ID", "title", constituency.partyID);
            ViewBag.stateID = new SelectList(db.States, "ID", "title", constituency.stateID);
            return View(constituency);
        }

        //
        // GET: /Constituency/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Constituency constituency = db.Constituencies.Find(id);
            if (constituency == null)
            {
                return HttpNotFound();
            }
            return View(constituency);
        }

        //
        // POST: /Constituency/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Constituency constituency = db.Constituencies.Find(id);
            db.Constituencies.Remove(constituency);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult GetConstituency(string query)
        {
            query = query.Replace(" ", "");
            if (query.Length > 1)
            {
                int op = query.LastIndexOf(",");
                query = query.Substring(op + 1);
            }
            var Constituencies = (from c in db.Constituencies
                                  where c.title.StartsWith(query)
                                  orderby c.title // optional
                                  select c.title).ToArray();

            return Json(Constituencies, JsonRequestBehavior.AllowGet);
        }
    }
}