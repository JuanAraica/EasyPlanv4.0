using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Modales.Models;

namespace Modales.Controllers
{
    public class TrabajadorController : Controller
    {
        private EasyPlanDB db = new EasyPlanDB();

        // GET: Trabajador
        public ActionResult Index()
        {
            if (Session["user"]==null)
            {
                return RedirectToAction("Index","Home");
            }
            return View(db.Tbl_Trabajador.ToList());
        }
        public ActionResult ListarTrabajadoes()
        {
            return PartialView(db.Tbl_Trabajador.ToList());
        }

        // GET: Trabajador/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Trabajador trabajador = db.Tbl_Trabajador.Find(id);
            if (trabajador == null)
            {
                return HttpNotFound();
            }
            return PartialView(trabajador);
        }

        // GET: Trabajador/Create
        public ActionResult CreateWorker()
        {
            return PartialView();
        }

      [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWorker( Tbl_Trabajador trabajador)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Trabajador.Add(trabajador);
                db.SaveChanges();
                return Json(new { success = true });
            }

            return PartialView(trabajador);
        }

        // GET: Trabajador/Edit/5
        public ActionResult EditWorker(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Trabajador trabajador = db.Tbl_Trabajador.Find(id);
            if (trabajador == null)
            {
                return HttpNotFound();
            }
            return PartialView(trabajador);
        }

       [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditWorker( Tbl_Trabajador trabajador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trabajador).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            return PartialView(trabajador);
        }

        // GET: Trabajador/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Trabajador trabajador = db.Tbl_Trabajador.Find(id);
            if (trabajador == null)
            {
                return HttpNotFound();
            }
            return PartialView(trabajador);
        }

        // POST: Trabajador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Tbl_Trabajador trabajador = db.Tbl_Trabajador.Find(id);
            db.Tbl_Trabajador.Remove(trabajador);
            db.SaveChanges();
            return Json(new { success = true });
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
