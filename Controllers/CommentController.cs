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
    public class CommentController : Controller
    {
        private CommentContext db = new CommentContext();

        //
        // GET: /Comment/

        public ActionResult Index()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var comments = db.Comments.Include(c => c.Member).Include(c => c.MP).Include(c => c.Sector);
                return View(comments.ToList());
            }             
        }

        //
        // GET: /Comment/Details/5

        public ActionResult Details(long id = 0)
        {
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        //
        // GET: /Comment/Create

        public ActionResult Create()
        {
            ViewBag.memberID = new SelectList(db.Members, "ID", "loginID");
            ViewBag.mpID = new SelectList(db.MPs, "ID", "firstName");
            ViewBag.sectorID = new SelectList(db.Sectors, "ID", "title");
            return View();
        }

        //
        // POST: /Comment/Create

        [HttpPost]
        public ActionResult Create(Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.memberID = new SelectList(db.Members, "ID", "loginID", comment.memberID);
            ViewBag.mpID = new SelectList(db.MPs, "ID", "firstName", comment.mpID);
            ViewBag.sectorID = new SelectList(db.Sectors, "ID", "title", comment.sectorID);
            return View(comment);
        }

        //
        // GET: /Comment/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.memberID = new SelectList(db.Members, "ID", "loginID", comment.memberID);
            ViewBag.mpID = new SelectList(db.MPs, "ID", "firstName", comment.mpID);
            ViewBag.sectorID = new SelectList(db.Sectors, "ID", "title", comment.sectorID);
            return View(comment);
        }

        //
        // POST: /Comment/Edit/5

        [HttpPost]
        public ActionResult Edit(Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.memberID = new SelectList(db.Members, "ID", "loginID", comment.memberID);
            ViewBag.mpID = new SelectList(db.MPs, "ID", "firstName", comment.mpID);
            ViewBag.sectorID = new SelectList(db.Sectors, "ID", "title", comment.sectorID);
            return View(comment);
        }

        //
        // GET: /Comment/Delete/5

        public ActionResult Delete(long id = 0)
        {
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        //
        // POST: /Comment/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
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