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
            foreach (var trabajador in db.Tbl_Trabajador.ToList())
            {
                trabajador.CedulaTra = Seguridad.DesEncriptar(trabajador.CedulaTra);
                trabajador.Correo = Seguridad.DesEncriptar(trabajador.Correo);
                trabajador.Nombre = Seguridad.DesEncriptar(trabajador.Nombre);
                trabajador.Apellido = Seguridad.DesEncriptar(trabajador.Apellido);
                trabajador.Telefono = Seguridad.DesEncriptar(trabajador.Telefono);
                trabajador.Puesto = Seguridad.DesEncriptar(trabajador.Puesto);
                trabajador.Direccion = Seguridad.DesEncriptar(trabajador.Direccion);
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
            trabajador.CedulaTra = Seguridad.DesEncriptar(trabajador.CedulaTra);
            trabajador.Correo = Seguridad.DesEncriptar(trabajador.Correo);
            trabajador.Nombre = Seguridad.DesEncriptar(trabajador.Nombre);
            trabajador.Apellido = Seguridad.DesEncriptar(trabajador.Apellido);
            trabajador.Telefono = Seguridad.DesEncriptar(trabajador.Telefono);
            trabajador.Puesto = Seguridad.DesEncriptar(trabajador.Puesto);
            trabajador.Direccion = Seguridad.DesEncriptar(trabajador.Direccion);
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
                trabajador.CedulaTra = Seguridad.Encriptar(trabajador.CedulaTra);
                trabajador.Correo = Seguridad.Encriptar(trabajador.Correo);
                trabajador.Nombre = Seguridad.Encriptar(trabajador.Nombre);
                trabajador.Apellido = Seguridad.Encriptar(trabajador.Apellido);
                trabajador.Telefono = Seguridad.Encriptar(trabajador.Telefono);
                trabajador.Puesto = Seguridad.Encriptar(trabajador.Puesto);
                trabajador.Direccion = Seguridad.Encriptar(trabajador.Direccion);
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
            Session["trabajador"] = trabajador.CedulaTra;
            return PartialView(trabajador);
        }

       [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditWorker( Tbl_Trabajador trabajador)
        {
            if (ModelState.IsValid)
            {
                trabajador.CedulaTra = (string)Session["trabajador"];
                db.Entry(trabajador).State = EntityState.Modified;
                db.SaveChanges();
                Session["trabajador"] = null;
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
