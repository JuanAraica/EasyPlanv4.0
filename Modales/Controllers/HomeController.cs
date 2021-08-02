using Modales.Models;
using System;
using System.Linq;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Modales.Controllers
{
    public class HomeController : Controller
    {

        private EasyPlanDB db = new EasyPlanDB();
 

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Tbl_Trabajador user)
        {

            if (ModelState.IsValid)
            {

                Tbl_Trabajador trabajador = db.Tbl_Trabajador.Find(user.CedulaTra);
 
                if (trabajador!=null)
                {
                    if (trabajador.Correo== user.Correo)
                    {
                        
                        RegistrarAccion("Ha iniciado sesión", trabajador.Nombre +" "+ trabajador.Apellido);
                        Session["user"] = trabajador.CedulaTra;

                        return Json(new { success = true });
                    }
                    ViewBag.Error = "Usuario o contraseña incorrecta";
                    return PartialView(user);
                }
                ViewBag.Error = "Usuario o contraseña invalida";
                return PartialView(user);
            }
            ViewBag.Error = "Usuario o contraseña invalida";
            return PartialView(user);
        }

        public ActionResult mostrarUser()
        {
            if ((string)Session["user"] !=null)
            {
                Tbl_Trabajador user = db.Tbl_Trabajador.Find((string)Session["user"]);
                return PartialView(user);
            }
            return null;

        }

        public ActionResult LogOut()
        {
            Tbl_Trabajador trabajador = db.Tbl_Trabajador.Find((string)Session["user"]);
            RegistrarAccion("Ha Cerrado sesión", trabajador.Nombre + " " + trabajador.Apellido);
            //Session["worker"] = null;
            Session["user"] = null;
            return RedirectToAction("Index");
        }



        public ActionResult History()
        {
            return View(db.Tbl_Historial.ToList());
        }
        public void RegistrarAccion(string registry, string user)
        {
            Tbl_Historial data = new Tbl_Historial();
            data.Usuario = user;
            data.Registro = registry;
            data.Fecha = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            db.Tbl_Historial.Add(data);
            db.SaveChanges();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }



        public ActionResult Mision()
        {

            return View();
        }
        public ActionResult Vision()
        {

            return View();
        }
        public ActionResult Objetives()
        {

            return View();
        }
        public ActionResult Projection()
        {
            return View();
        }
        public ActionResult Values()
        {

            return View();
        }
    }
}