﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class ApplicantsController : Controller
    {
        private ApplicantDBContext db = new ApplicantDBContext();

        //
        // GET: /Applicants/

        public ActionResult Index()
        {
            return View(db.Applicants.ToList());
        }

        //
        // GET: /Applicants/Details/5

        public ActionResult Details(int id = 0)
        {
            Applicant applicant = db.Applicants.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        //
        // GET: /Applicants/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Applicants/Create

        [HttpPost]
        public ActionResult Create(Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                db.Applicants.Add(applicant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(applicant);
        }

        //
        // GET: /Applicants/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Applicant applicant = db.Applicants.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        //
        // POST: /Applicants/Edit/5

        [HttpPost]
        public ActionResult Edit(Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicant);
        }

        //
        // GET: /Applicants/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Applicant applicant = db.Applicants.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        //
        // POST: /Applicants/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Applicant applicant = db.Applicants.Find(id);
            db.Applicants.Remove(applicant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Search Index
        public ActionResult SearchIndex(string appDegree, string searchString)
        {
            var DegreeLst = new List<string>();

            var DegreeQry = from d in db.Applicants
                           orderby d.Degree
                           select d.Degree;
            DegreeLst.AddRange(DegreeQry.Distinct());
            ViewBag.appDegree = new SelectList(DegreeLst);

            var applicants = from m in db.Applicants
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                applicants = applicants.Where(s => s.Languages.Contains(searchString));
            }

            if (string.IsNullOrEmpty(appDegree))
                return View(applicants);
            else
            {
                return View(applicants.Where(x => x.Degree == appDegree));
            }

        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}