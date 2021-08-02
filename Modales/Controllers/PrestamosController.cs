using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Modales.Models;

namespace Modales.Controllers
{
    public class PrestamosController : Controller
    {
        private EasyPlanDB db = new EasyPlanDB();

        // GET: Prestamos
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var prestamos = db.Tbl_Prestamos.Include(t => t.Tbl_Trabajador);
            return View(prestamos.ToList());
        }

        // GET: Prestamos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Prestamos prestamo = db.Tbl_Prestamos.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            return PartialView(prestamo);
        }

        // GET: Prestamos/Create
        public ActionResult Create()
        {
            ViewBag.CedulaTra = new SelectList(db.Tbl_Trabajador, "CedulaTra", "Nombre");
            return PartialView();
        }
 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Tbl_Prestamos prestamo)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Prestamos.Add(prestamo);
                db.SaveChanges();
                return Json(new { success = true });
            }
            ViewBag.CedulaTra = new SelectList(db.Tbl_Trabajador, "CedulaTra", "Nombre", prestamo.CedulaTra);
            return PartialView(prestamo);
        }

        // GET: Prestamos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Prestamos prestamo = db.Tbl_Prestamos.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            Session["trabajador"] = prestamo.CedulaTra;
            Session["prestamo"] = prestamo.idPrestamo;
            ViewBag.CedulaTra = new SelectList(db.Tbl_Trabajador, "CedulaTra", "Nombre", prestamo.CedulaTra);
            return PartialView(prestamo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Tbl_Prestamos prestamo)
        {
            if (ModelState.IsValid)
            {
                prestamo.idPrestamo = (int)Session["prestamo"];
                prestamo.CedulaTra = (string)Session["trabajador"];
                db.Entry(prestamo).State = EntityState.Modified;
                db.SaveChanges();
                Session["trabajador"] = null;
                Session["prestamo"] = null;
                return Json(new { success = true });
            }
            ViewBag.CedulaTra = new SelectList(db.Tbl_Trabajador, "CedulaTra", "Nombre", prestamo.CedulaTra);
            return PartialView(prestamo);
        }

        // GET: Prestamos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Prestamos prestamo = db.Tbl_Prestamos.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            return PartialView(prestamo);
        }

        // POST: Prestamos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Prestamos prestamo = db.Tbl_Prestamos.Find(id);
            db.Tbl_Prestamos.Remove(prestamo);
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
