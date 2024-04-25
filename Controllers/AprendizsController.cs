using System;
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
    public class AprendizsController : Controller
    {
        private AssitAdsoEntities db = new AssitAdsoEntities();

        // GET: Aprendizs
        public ActionResult Index()
        {
            var aprendiz = db.Aprendiz.Include(a => a.Ficha);
            return View(aprendiz.ToList());
        }

        // GET: Aprendizs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aprendiz aprendiz = db.Aprendiz.Find(id);
            if (aprendiz == null)
            {
                return HttpNotFound();
            }
            return View(aprendiz);
        }

        // GET: Aprendizs/Create
        public ActionResult Create()
        {
            ViewBag.Id_ficha = new SelectList(db.Ficha, "Id_ficha", "Jornada_ficha");
            return View();
        }

        // POST: Aprendizs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_aprendiz,Nombre_aprendiz,Apellido_aprendiz,Telefono_aprendiz,Correo_aprendiz,Id_ficha")] Aprendiz aprendiz)
        {
            if (ModelState.IsValid)
            {
                db.Aprendiz.Add(aprendiz);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_ficha = new SelectList(db.Ficha, "Id_ficha", "Jornada_ficha", aprendiz.Id_ficha);
            return View(aprendiz);
        }

        // GET: Aprendizs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aprendiz aprendiz = db.Aprendiz.Find(id);
            if (aprendiz == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_ficha = new SelectList(db.Ficha, "Id_ficha", "Jornada_ficha", aprendiz.Id_ficha);
            return View(aprendiz);
        }

        // POST: Aprendizs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_aprendiz,Nombre_aprendiz,Apellido_aprendiz,Telefono_aprendiz,Correo_aprendiz,Id_ficha")] Aprendiz aprendiz)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aprendiz).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_ficha = new SelectList(db.Ficha, "Id_ficha", "Jornada_ficha", aprendiz.Id_ficha);
            return View(aprendiz);
        }

        // GET: Aprendizs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aprendiz aprendiz = db.Aprendiz.Find(id);
            if (aprendiz == null)
            {
                return HttpNotFound();
            }
            return View(aprendiz);
        }

        // POST: Aprendizs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aprendiz aprendiz = db.Aprendiz.Find(id);
            db.Aprendiz.Remove(aprendiz);
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
