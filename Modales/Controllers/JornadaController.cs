using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Modales.Models;

namespace Modales.Controllers
{
    public class JornadaController : Controller
    {
        private EasyPlanDB db = new EasyPlanDB();

        // GET: Jornada
        public ActionResult Index()
        {
            //if (Session["user"] == null)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            return View(db.Tbl_Jornada.ToList());
        }

        // GET: Jornada/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Jornada jornada = db.Tbl_Jornada.Find(id);
            if (jornada == null)
            {
                return HttpNotFound();
            }
            return PartialView(jornada);
        }

        // GET: Jornada/Create
        public ActionResult CreateJornadaCarga()
        {
            ViewBag.CedulaTra = new SelectList(db.Tbl_Trabajador, "CedulaTra", "Nombre");
            return PartialView();
        }
        public ActionResult CreateJornadaContrato()
        {
            ViewBag.CedulaTra = new SelectList(db.Tbl_Trabajador, "CedulaTra", "Nombre");
            return PartialView();
        }
        public ActionResult CreateJornadaCorta()
        {
            ViewBag.CedulaTra = new SelectList(db.Tbl_Trabajador, "CedulaTra", "Nombre");
            return PartialView();
        }
        public ActionResult CreateJornadaSiembra()
        {
            ViewBag.CedulaTra = new SelectList(db.Tbl_Trabajador, "CedulaTra", "Nombre");
            return PartialView();
        }
        public ActionResult CreateJornadaRetapa()
        {
            ViewBag.CedulaTra = new SelectList(db.Tbl_Trabajador, "CedulaTra", "Nombre");
            return PartialView();
        }
        public ActionResult CreateJornadaDescarga()
        {
            ViewBag.CedulaTra = new SelectList(db.Tbl_Trabajador, "CedulaTra", "Nombre");
            return PartialView();
        }
        public ActionResult CreateJornadaHora()
        {
            ViewBag.CedulaTra = new SelectList(db.Tbl_Trabajador, "CedulaTra", "Nombre");
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateJornadaCorta(Tbl_Jornada jornada)
        {
            if (ModelState.IsValid)
            {
                jornada.TipoJornada = "Corta";
                jornada.UnidadMedida = "Paquetes";
                jornada.ValorJornada = jornada.PrecioUnidadMedida*jornada.TotalUnidadDeMedida;
                db.Tbl_Jornada.Add(jornada);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return PartialView(jornada);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateJornadaSiembra(Tbl_Jornada jornada)
        {
            if (ModelState.IsValid)
            {
                jornada.TipoJornada = "Siembra";
                jornada.UnidadMedida = "Metro";
                jornada.ValorJornada = jornada.PrecioUnidadMedida * jornada.TotalUnidadDeMedida;
                db.Tbl_Jornada.Add(jornada);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return PartialView(jornada);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateJornadaRetapa(Tbl_Jornada jornada)
        {
            if (ModelState.IsValid)
            {
                jornada.TipoJornada = "Retapa";
                jornada.UnidadMedida = "Metro";
                jornada.ValorJornada = jornada.PrecioUnidadMedida * jornada.TotalUnidadDeMedida;
                db.Tbl_Jornada.Add(jornada);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return PartialView(jornada);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateJornadaCarga(Tbl_Jornada jornada)
        {
            if (ModelState.IsValid)
            {
                jornada.TipoJornada = "Carga";
                jornada.UnidadMedida = "Paquete";
                jornada.ValorJornada = jornada.PrecioUnidadMedida * jornada.TotalUnidadDeMedida;
                db.Tbl_Jornada.Add(jornada);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return PartialView(jornada);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateJornadaDescarga(Tbl_Jornada jornada)
        {
            if (ModelState.IsValid)
            {
                jornada.TipoJornada = "Descarga";
                jornada.UnidadMedida = "Paquete";
                jornada.ValorJornada = jornada.PrecioUnidadMedida * jornada.TotalUnidadDeMedida;
                db.Tbl_Jornada.Add(jornada);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return PartialView(jornada);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateJornadaHora(Tbl_Jornada jornada)
        {
            if (ModelState.IsValid)
            {
                DateTime entrada = Convert.ToDateTime(jornada.HoraInicio);
                DateTime Salida = Convert.ToDateTime(jornada.HoraFin);

                double totalHoras = entrada.Subtract(Salida).TotalHours;
                jornada.TipoJornada = "Por Hora";
                jornada.UnidadMedida = "Hora";
                jornada.ValorJornada = jornada.ValorTotalHorasRegulares * jornada.ValorTotalHoraExtra;
                db.Tbl_Jornada.Add(jornada);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return PartialView(jornada);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateJornadaContrato(Tbl_Jornada jornada)
        {
            if (ModelState.IsValid)
            {
                jornada.TipoJornada = "Contrato/Tarea";
                jornada.UnidadMedida = "Contrato/Tarea";
                jornada.PrecioUnidadMedida = jornada.PrecioContrato;
                jornada.ValorJornada = jornada.PrecioContrato;
                db.Tbl_Jornada.Add(jornada);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return PartialView(jornada);
        }







        // GET: Jornada/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Jornada jornada = db.Tbl_Jornada.Find(id);
            Session["trabajador"] = jornada.CedulaTra;
            Session["jornada"] = jornada.idJornada;
            if (jornada == null)
            {
                return HttpNotFound();
            }
            return PartialView(jornada);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tbl_Jornada jornada)
        {
            if (ModelState.IsValid)
            {
                jornada.idJornada = (int)Session["jornada"];
                jornada.CedulaTra = (string)Session["trabajador"];
                db.Entry(jornada).State = EntityState.Modified;
                db.SaveChanges();
                Session["trabajador"] = null;
                Session["jornada"] = null;
                return Json(new { success = true });
            }
            return PartialView(jornada);
        }


        public ActionResult EditJornadaCarga(int? id)
        {
            Tbl_Jornada jornada = db.Tbl_Jornada.Find(id);
            Session["trabajador"] = jornada.CedulaTra;
            Session["jornada"] = jornada.idJornada;
            if (jornada == null)
            {
                return HttpNotFound();
            }
            return PartialView(jornada);
        }
        public ActionResult EditJornadaContrato(int? id)
        {
            Tbl_Jornada jornada = db.Tbl_Jornada.Find(id);
            Session["trabajador"] = jornada.CedulaTra;
            Session["jornada"] = jornada.idJornada;
            return PartialView(jornada);
        }
        public ActionResult EditJornadaCorta(int? id)
        {
            Tbl_Jornada jornada = db.Tbl_Jornada.Find(id);
            Session["trabajador"] = jornada.CedulaTra;
            Session["jornada"] = jornada.idJornada;
            return PartialView(jornada);
        }
        public ActionResult EditJornadaSiembra(int? id)
        {
            Tbl_Jornada jornada = db.Tbl_Jornada.Find(id);
            Session["trabajador"] = jornada.CedulaTra;
            Session["jornada"] = jornada.idJornada;
            return PartialView(jornada);
        }
        public ActionResult EditJornadaRetapa(int? id)
        {
            Tbl_Jornada jornada = db.Tbl_Jornada.Find(id);
            Session["trabajador"] = jornada.CedulaTra;
            Session["jornada"] = jornada.idJornada;
            return PartialView(jornada);
        }
        public ActionResult EditJornadaDescarga(int? id)
        {
            Tbl_Jornada jornada = db.Tbl_Jornada.Find(id);
            Session["trabajador"] = jornada.CedulaTra;
            Session["jornada"] = jornada.idJornada;
            return PartialView(jornada);
        }
        public ActionResult EditJornadaHora(int? id)
        {
            Tbl_Jornada jornada = db.Tbl_Jornada.Find(id);
            Session["trabajador"] = jornada.CedulaTra;
            Session["jornada"] = jornada.idJornada;
            return PartialView(jornada);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditJornadaCorta(Tbl_Jornada jornada)
        {
            if (ModelState.IsValid)
            {
                jornada.TipoJornada = "Corta";
                jornada.UnidadMedida = "Paquetes";
                jornada.ValorJornada = jornada.PrecioUnidadMedida * jornada.TotalUnidadDeMedida;
                jornada.idJornada = (int)Session["jornada"];
                jornada.CedulaTra = (string)Session["trabajador"];
                db.Entry(jornada).State = EntityState.Modified;
                db.SaveChanges();
                Session["trabajador"] = null;
                Session["jornada"] = null;
                return Json(new { success = true });
            }
            return PartialView(jornada);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditJornadaSiembra(Tbl_Jornada jornada)
        {
            if (ModelState.IsValid)
            {
                jornada.TipoJornada = "Siembra";
                jornada.UnidadMedida = "Metro";
                jornada.ValorJornada = jornada.PrecioUnidadMedida * jornada.TotalUnidadDeMedida;
                jornada.idJornada = (int)Session["jornada"];
                jornada.CedulaTra = (string)Session["trabajador"];
                db.Entry(jornada).State = EntityState.Modified;
                db.SaveChanges();
                Session["trabajador"] = null;
                Session["jornada"] = null;
                return Json(new { success = true });
            }
            return PartialView(jornada);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditJornadaRetapa(Tbl_Jornada jornada)
        {
            if (ModelState.IsValid)
            {
                jornada.TipoJornada = "Retapa";
                jornada.UnidadMedida = "Metro";
                jornada.ValorJornada = jornada.PrecioUnidadMedida * jornada.TotalUnidadDeMedida;
                jornada.idJornada = (int)Session["jornada"];
                jornada.CedulaTra = (string)Session["trabajador"];
                db.Entry(jornada).State = EntityState.Modified;
                db.SaveChanges();
                Session["trabajador"] = null;
                Session["jornada"] = null;
                return Json(new { success = true });
            }
            return PartialView(jornada);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditJornadaCarga(Tbl_Jornada jornada)
        {
            if (ModelState.IsValid)
            {
                jornada.TipoJornada = "Carga";
                jornada.UnidadMedida = "Paquete";
                jornada.ValorJornada = jornada.PrecioUnidadMedida * jornada.TotalUnidadDeMedida;
                jornada.idJornada = (int)Session["jornada"];
                jornada.CedulaTra = (string)Session["trabajador"];
                db.Entry(jornada).State = EntityState.Modified;
                db.SaveChanges();
                Session["trabajador"] = null;
                Session["jornada"] = null;
                return Json(new { success = true });
            }
            return PartialView(jornada);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditJornadaDescarga(Tbl_Jornada jornada)
        {
            if (ModelState.IsValid)
            {
                jornada.TipoJornada = "Descarga";
                jornada.UnidadMedida = "Paquete";
                jornada.ValorJornada = jornada.PrecioUnidadMedida * jornada.TotalUnidadDeMedida;
                jornada.idJornada = (int)Session["jornada"];
                jornada.CedulaTra = (string)Session["trabajador"];
                db.Entry(jornada).State = EntityState.Modified;
                db.SaveChanges();
                Session["trabajador"] = null;
                Session["jornada"] = null;
                return Json(new { success = true });
            }
            return PartialView(jornada);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditJornadaHora(Tbl_Jornada jornada)
        {
            if (ModelState.IsValid)
            {
                DateTime entrada = Convert.ToDateTime(jornada.HoraInicio);
                DateTime Salida = Convert.ToDateTime(jornada.HoraFin);

                double totalHoras = entrada.Subtract(Salida).TotalHours;
                jornada.TipoJornada = "Por Hora";
                jornada.UnidadMedida = "Hora";
                jornada.ValorJornada = jornada.ValorTotalHorasRegulares * jornada.ValorTotalHoraExtra;
                jornada.idJornada = (int)Session["jornada"];
                jornada.CedulaTra = (string)Session["trabajador"];
                db.Entry(jornada).State = EntityState.Modified;
                db.SaveChanges();
                Session["trabajador"] = null;
                Session["jornada"] = null;
                return Json(new { success = true });
            }
            return PartialView(jornada);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditJornadaContrato(Tbl_Jornada jornada)
        {
            if (ModelState.IsValid)
            {
                jornada.TipoJornada = "Contrato/Tarea";
                jornada.UnidadMedida = "Contrato/Tarea";
                jornada.ValorJornada = jornada.PrecioContrato;
                jornada.idJornada = (int)Session["jornada"];
                jornada.CedulaTra = (string)Session["trabajador"];
                db.Entry(jornada).State = EntityState.Modified;
                db.SaveChanges();
                Session["trabajador"] = null;
                Session["jornada"] = null;
                return Json(new { success = true });
            }
            return PartialView(jornada);
        }




        // GET: Jornada/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Jornada jornada = db.Tbl_Jornada.Find(id);
            if (jornada == null)
            {
                return HttpNotFound();
            }
            return PartialView(jornada);
        }

        // POST: Jornada/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Jornada jornada = db.Tbl_Jornada.Find(id);
            db.Tbl_Jornada.Remove(jornada);
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
