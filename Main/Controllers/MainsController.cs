﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Main.Models;

namespace Main.Controllers
{

    public class MainsController : Controller
    {
        private LoginDBContext db = new LoginDBContext();
        // GET: Mains
        public ActionResult Index()
        {
            
            return View(db.Mains.ToList());
        }

        // GET: Mains/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Main main = db.Mains.Find(id);
            if (main == null)
            {
                return HttpNotFound();
            }
            return View(main);
        }

        // GET: Mains/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mains/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Password")] Models.Main main)
        {
            if (ModelState.IsValid)
            {
                main.LastLogin = DateTime.Now;
                db.Mains.Add(main);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(main);
        }

        // GET: Mains/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Main main = db.Mains.Find(id);
            if (main == null)
            {
                return HttpNotFound();
            }
            return View(main);
        }

        // POST: Mains/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Password")] Models.Main main)
        {
            if (ModelState.IsValid)
            {
                db.Entry(main).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(main);
        }

        // GET: Mains/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Main main = db.Mains.Find(id);
            if (main == null)
            {
                return HttpNotFound();
            }
            return View(main);
        }

        // POST: Mains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Models.Main main = db.Mains.Find(id);
            db.Mains.Remove(main);
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
