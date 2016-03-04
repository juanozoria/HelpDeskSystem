using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaLogica_HelpDesk;

namespace HelpDesk.Controllers
{
    public class UsuariosController : Controller
    {

        [HttpPost]
        public ActionResult NuevoUsuario(Usuarios user)
        {
            ViewData["DepartmentId"] = new SelectList(CapaLogica_HelpDesk.Departamentos.ListDeparments(), "IdDeparment", "Departamento");
            ViewData["IdTipoUsuario"] = new SelectList(CapaLogica_HelpDesk.TipodeUsuario.ListTipoUsuarios(),"IdTipoUsuario","TipoUsuario");


            try
            {
                Funciones.EncodePassword(user.Contrasena);
                user.InsertUsuario();
                Funciones.MostrarSuccess(this, "El usuario se ha registrado exitosamente!");
            }
            catch (Exception ex)
            {

                Funciones.MostrarError(this, ex);
                return View(user);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public ActionResult NuevoUsuario()
        {
            ViewData["DepartmentId"] = new SelectList(CapaLogica_HelpDesk.Departamentos.ListDeparments(), "IdDeparment", "Departamento");
            ViewData["IdTipoUsuario"] = new SelectList(CapaLogica_HelpDesk.TipodeUsuario.ListTipoUsuarios(), "IdTipoUsuario", "TipoUsuario");

            Usuarios user = new Usuarios();
            return View(user);
        }

    }
}
