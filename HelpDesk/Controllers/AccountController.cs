using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaLogica_HelpDesk;
using System.Web.Security;

namespace HelpDesk.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }
        
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(Usuarios user, string NombreUsuario, string Contrasena)
        {
            try
            {
                user = new Usuarios();
                user.Login(NombreUsuario,Contrasena);
                FormsAuthentication.SetAuthCookie(user.IdUsuario.ToString(), false);
            }
            catch (Exception ex)
            {
                Funciones.MostrarError(this, ex);
                return View(user);
            }
            return  RedirectToAction("ConsultaMasiva", "Soporte");
        }


        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

    }
}
