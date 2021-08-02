using Modales.Controllers;
using Modales.Models;
using System;
using System.Web;
using System.Web.Mvc;
using ActionFilterAttribute = System.Web.Mvc.ActionFilterAttribute;

namespace Modales.Filters
{
    public class VerificaSession : ActionFilterAttribute
    {
        private Tbl_Trabajador oUsuario;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);
                oUsuario = (Tbl_Trabajador)HttpContext.Current.Session["User"];
                if (oUsuario == null)
                {
                    if (filterContext.Controller is TrabajadorController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/Trabajador/Index");
                    }
                }
            }
            catch (Exception)
            {
                filterContext.Result = new RedirectResult("/Home/Index");
            }

        }
    }
}