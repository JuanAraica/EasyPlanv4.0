using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Modales.Models;

namespace Modales.Controllers
{
    public class AdelantosController : Controller
    {
        private EasyPlanDB db = new EasyPlanDB();

        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(db.Tbl_Adelantos.ToList());
        }

        // GET: Adelantos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Adelantos tbl_Adelantos = db.Tbl_Adelantos.Find(id);
            if (tbl_Adelantos == null)
            {
                return HttpNotFound();
            }
            return PartialView(tbl_Adelantos);
        }

        // GET: Adelantos/Create
        public ActionResult Create()
        {
            return PartialView();
        }

       [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tbl_Adelantos adelanto)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Adelantos.Add(adelanto);
                db.SaveChanges();
                return Json(new { success = true });
            }
           return PartialView(adelanto);
        }

        // GET: Adelantos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Adelantos adelanto = db.Tbl_Adelantos.Find(id);
            if (adelanto == null)
            {
                return HttpNotFound();
            }
          return PartialView(adelanto);
        }

       [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tbl_Adelantos adelanto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adelanto).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
          return PartialView(adelanto);
        }

        // GET: Adelantos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Adelantos adelanto = db.Tbl_Adelantos.Find(id);
            if (adelanto == null)
            {
                return HttpNotFound();
            }
            return PartialView(adelanto);
        }

        // POST: Adelantos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Adelantos adelanto = db.Tbl_Adelantos.Find(id);
            db.Tbl_Adelantos.Remove(adelanto);
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
