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
    public class ClientesController : Controller
    {
        private EasyPlanDB db = new EasyPlanDB();

        // GET: Clientes
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(db.Tbl_Clientes.ToList());
        }

        public ActionResult CreateModal()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateModal(Tbl_Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Clientes.Add(clientes);
                db.SaveChanges();
                return Json(new { success = true });
            }
            else
            {
                return PartialView(clientes);
            }
        }


        // GET: Clientes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Clientes cliente = db.Tbl_Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return PartialView(cliente);
        }


        // GET: Clientes/Edit/5
        public ActionResult EditClient(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Clientes cliente = db.Tbl_Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return PartialView(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditClient(Tbl_Clientes cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            return PartialView(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Clientes cliente = db.Tbl_Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return PartialView(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Tbl_Clientes cliente = db.Tbl_Clientes.Find(id);
            db.Tbl_Clientes.Remove(cliente);
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
