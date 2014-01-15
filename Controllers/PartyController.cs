﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Politico.Models;
using System.Web.Security;

namespace Politico.Controllers
{
    public class PartyController : Controller
    {
        private PartyContext db = new PartyContext();

        //
        // GET: /Party/

        public ActionResult Index()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return View(db.Parties.ToList());
            }
        }

        //
        // GET: /Party/Details/5

        public ActionResult Details(int id = 0)
        {
            Party party = db.Parties.Find(id);
            if (party == null)
            {
                return HttpNotFound();
            }
            return View(party);
        }

        //
        // GET: /Party/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Party/Create

        [HttpPost]
        public ActionResult Create(Party party)
        {
            if (ModelState.IsValid)
            {
                db.Parties.Add(party);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(party);
        }

        //
        // GET: /Party/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Party party = db.Parties.Find(id);
            if (party == null)
            {
                return HttpNotFound();
            }
            return View(party);
        }

        //
        // POST: /Party/Edit/5

        [HttpPost]
        public ActionResult Edit(Party party)
        {
            if (ModelState.IsValid)
            {
                db.Entry(party).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(party);
        }

        //
        // GET: /Party/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Party party = db.Parties.Find(id);
            if (party == null)
            {
                return HttpNotFound();
            }
            return View(party);
        }

        //
        // POST: /Party/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Party party = db.Parties.Find(id);
            db.Parties.Remove(party);
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