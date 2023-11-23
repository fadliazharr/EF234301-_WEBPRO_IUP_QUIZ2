using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LearnSpace;

namespace LearnSpace.Controllers
{
    public class spacesController : Controller
    {
        private LearnSpace_dbEntities db = new LearnSpace_dbEntities();

        // GET: spaces
        public ActionResult Index()
        {
            return View(db.spaces.ToList());
        }

        // GET: spaces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            space space = db.spaces.Find(id);
            if (space == null)
            {
                return HttpNotFound();
            }
            return View(space);
        }

        // GET: spaces/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: spaces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,space1,duration")] space space)
        {
            if (ModelState.IsValid)
            {
                db.spaces.Add(space);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(space);
        }

        // GET: spaces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            space space = db.spaces.Find(id);
            if (space == null)
            {
                return HttpNotFound();
            }
            return View(space);
        }

        // POST: spaces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,space1,duration")] space space)
        {
            if (ModelState.IsValid)
            {
                db.Entry(space).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(space);
        }

        // GET: spaces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            space space = db.spaces.Find(id);
            if (space == null)
            {
                return HttpNotFound();
            }
            return View(space);
        }

        // POST: spaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            space space = db.spaces.Find(id);
            db.spaces.Remove(space);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
