﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Politico.Models;

namespace Politico.Controllers
{
    public class StateController : Controller
    {
        private StateContext db = new StateContext();

        //
        // GET: /State/

        public ActionResult Index()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return View(db.States.ToList());
            }                   
        }

        //
        // GET: /State/Details/5

        public ActionResult Details(int id = 0)
        {
            State state = db.States.Find(id);
            if (state == null)
            {
                return HttpNotFound();
            }
            return View(state);
        }

        //
        // GET: /State/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /State/Create

        [HttpPost]
        public ActionResult Create(State state)
        {
            if (ModelState.IsValid)
            {
                db.States.Add(state);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(state);
        }

        //
        // GET: /State/Edit/5

        public ActionResult Edit(int id = 0)
        {
            State state = db.States.Find(id);
            if (state == null)
            {
                return HttpNotFound();
            }
            return View(state);
        }

        //
        // POST: /State/Edit/5

        [HttpPost]
        public ActionResult Edit(State state)
        {
            if (ModelState.IsValid)
            {
                db.Entry(state).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(state);
        }

        //
        // GET: /State/Delete/5

        public ActionResult Delete(int id = 0)
        {
            State state = db.States.Find(id);
            if (state == null)
            {
                return HttpNotFound();
            }
            return View(state);
        }

        //
        // POST: /State/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            State state = db.States.Find(id);
            db.States.Remove(state);
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