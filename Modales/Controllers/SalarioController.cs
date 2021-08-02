using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Modales.Models;

namespace Modales.Controllers
{
    public class SalarioController : Controller
    {
        private EasyPlanDB db = new EasyPlanDB();


        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var tbl_Salario = db.Tbl_Salario.Include(t => t.Tbl_Trabajador);
            return View(tbl_Salario.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Salario salario = db.Tbl_Salario.Find(id);
            if (salario == null)
            {
                return HttpNotFound();
            }
            return PartialView(salario);
        }

        public ActionResult CreateSalary()
        {
            ViewBag.CedulaTra = new SelectList(db.Tbl_Trabajador, "CedulaTra", "Nombre");
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSalary(Tbl_Salario salario)
        {
            if (ModelState.IsValid)
            {
                salario.Seguro = (int)(salario.SalarioBruto * 0.12);
                salario.TotalDeducciones = (int)(salario.Adelantos + salario.Otros + salario.Prestamos + salario.Seguro);
                salario.SalarioNeto = salario.SalarioBruto - salario.TotalDeducciones;
                db.Tbl_Salario.Add(salario);
                db.SaveChanges();
                return Json(new { success = true });
            }
            ViewBag.CedulaTra = new SelectList(db.Tbl_Trabajador, "CedulaTra", "Nombre", salario.CedulaTra);
            return PartialView(salario);
        }

        // GET: Salario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Salario salario = db.Tbl_Salario.Find(id);
            if (salario == null)
            {
                return HttpNotFound();
            }
            return PartialView(salario);
        }

        // POST: Salario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Salario salario = db.Tbl_Salario.Find(id);
            db.Tbl_Salario.Remove(salario);
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

        public ActionResult EditSal(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Salario salario = db.Tbl_Salario.Find(id);
            if (salario == null)
            {
                return HttpNotFound();
            }
            Session["trabajador"] = salario.CedulaTra;
            ViewBag.CedulaTra = new SelectList(db.Tbl_Trabajador, "CedulaTra", "Nombre", salario.CedulaTra);
            return PartialView(salario);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSal(Tbl_Salario salario)
        {
            if (ModelState.IsValid)
            {
                salario.Seguro = (int)(salario.SalarioBruto * 0.12);
                salario.TotalDeducciones = (int)(salario.Adelantos + salario.Otros + salario.Prestamos + salario.Seguro);
                salario.SalarioNeto = salario.SalarioBruto - salario.TotalDeducciones;
                salario.CedulaTra = (string)Session["trabajador"];
                db.Entry(salario).State = EntityState.Modified;
                db.SaveChanges();
                Session["trabajador"] = null;
                return Json(new { success = true });
            }
            ViewBag.CedulaTra = new SelectList(db.Tbl_Trabajador, "CedulaTra", "Nombre", salario.CedulaTra);
            return PartialView(salario);
        }

    }
}
