﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClaseDatos;

namespace AssistADSO.Controllers
{
    public class CompetenciasController : Controller
    {
        private AssitAdsoEntities db = new AssitAdsoEntities();

        // GET: Competencias
        public ActionResult Index()
        {
            var competencia = db.Competencia.Include(c => c.Ficha);
            return View(competencia.ToList());
        }

        // GET: Competencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competencia competencia = db.Competencia.Find(id);
            if (competencia == null)
            {
                return HttpNotFound();
            }
            return View(competencia);
        }

        // GET: Competencias/Create
        public ActionResult Create()
        {
            ViewBag.Id_ficha = new SelectList(db.Ficha, "Id_ficha", "Jornada_ficha");
            return View();
        }

        // POST: Competencias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Competencia,Nombre_Competencia,tipo_competencia,Modalidad_competencia,Id_ficha")] Competencia competencia)
        {
            if (ModelState.IsValid)
            {
                db.Competencia.Add(competencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_ficha = new SelectList(db.Ficha, "Id_ficha", "Jornada_ficha", competencia.Id_ficha);
            return View(competencia);
        }

        // GET: Competencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competencia competencia = db.Competencia.Find(id);
            if (competencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_ficha = new SelectList(db.Ficha, "Id_ficha", "Jornada_ficha", competencia.Id_ficha);
            return View(competencia);
        }

        // POST: Competencias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Competencia,Nombre_Competencia,tipo_competencia,Modalidad_competencia,Id_ficha")] Competencia competencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(competencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_ficha = new SelectList(db.Ficha, "Id_ficha", "Jornada_ficha", competencia.Id_ficha);
            return View(competencia);
        }

        // GET: Competencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competencia competencia = db.Competencia.Find(id);
            if (competencia == null)
            {
                return HttpNotFound();
            }
            return View(competencia);
        }

        // POST: Competencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Competencia competencia = db.Competencia.Find(id);
            db.Competencia.Remove(competencia);
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
