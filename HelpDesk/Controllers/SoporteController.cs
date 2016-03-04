using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaLogica_HelpDesk;
using System.IO;

namespace HelpDesk.Controllers
{
    [Authorize]
    public class SoporteController : Controller
    {
        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            // Verify that the user selected a file
            if (file != null && file.ContentLength > 0)
            {
                // extract only the filename
                var fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/images"), fileName);
                file.SaveAs(path);
            }
            // redirect back to the index action to show the form once again
            return View();
        }

        [HttpPost]
        public ActionResult RegistroSoporte(Soporte soport, HttpPostedFileBase file)
        {
            //ESTO es usado para llenar LOS DROPDOWNLIST EN LA VISTA! debe estar en el post y en el get
            ViewData["DepartamentId"] = new SelectList(CapaLogica_HelpDesk.Departamentos.ListDeparments(), "IdDeparment", "Departamento");
            ViewData["IdProblem"] = new SelectList(CapaLogica_HelpDesk.Problemas.ListProblems(), "IdProblema", "Descripcion");
            ViewData["IdTipoSolicitud"] = new SelectList(CapaLogica_HelpDesk.Solicitudes.TipoSolicitudes(), "IdSolicitud", "TipoSolicitud");
            ViewData["IdSeveridad"] = new SelectList(CapaLogica_HelpDesk.Severidades.ListSeveridad(), "IdSeveridad", "Severidad");
            ViewData["IdEstado"] = new SelectList(CapaLogica_HelpDesk.Estados.ListEstados(), "IdEstado", "Estado");


            try
            {
                if (!string.IsNullOrEmpty(Request["FechaRegistro"].ToString()))
                    soport.FechaRegistro = DateTime.ParseExact(Request["FechaRegistro"].ToString(), "dd-MM-yyyy", null);
                soport.IdUsuario = int.Parse(User.Identity.Name);
                //registrar photo
                // Verify that the user selected a file
                if (file != null && file.ContentLength > 0)
                {
                    // extract only the filename
                    var fileName = DateTime.Now.ToString("dd-MM-yyyy")
                                 + DateTime.Now.Millisecond.ToString() 
                                 + Path.GetFileName(file.FileName.Replace(" ",""));
                    // store the file inside ~/App_Data/uploads folder
                    var path = Path.Combine(Server.MapPath("~/images/"), fileName);
                    soport.imagepath = fileName;
                    file.SaveAs(path);
                }


                //insert soporte
                soport.RegistrarSoporte();
            }
            catch (Exception ex)
            {

                Funciones.MostrarError(this, ex);
                return View(soport);
            }

            var idtipouser = Usuarios.GetOne(int.Parse(User.Identity.Name)).IdTipoUsuario;

            if (idtipouser == 3)
            {
                return RedirectToAction("ConsultaMasiva", "Soporte");
            }
            else {
                return RedirectToAction("DetalleSoporte", new { id = soport.IdSoporte });
            }
        }

        [HttpGet]
        public ActionResult DetalleSoporte(int id)
        {

            
            
            try
            {

                var soport = Soporte.GetOneSoporte(id);
               
                return View(soport);
            }
            catch (Exception ex)
            {
                Funciones.MostrarError(this, ex);
                return RedirectToAction("RegistroSoporte");
            }
        }

        [HttpGet]
        public ActionResult ModificarSolicitud(int id)
        {
            //ESTO es usado para llenar LOS DROPDOWNLIST EN LA VISTA! debe estar en el post y en el get
            ViewData["DepartamentId"] = new SelectList(CapaLogica_HelpDesk.Departamentos.ListDeparments(), "IdDeparment", "Departamento");
            ViewData["IdProblem"] = new SelectList(CapaLogica_HelpDesk.Problemas.ListProblems(), "IdProblema", "Descripcion");
            ViewData["IdTipoSolicitud"] = new SelectList(CapaLogica_HelpDesk.Solicitudes.TipoSolicitudes(), "IdSolicitud", "TipoSolicitud");
            ViewData["IdSeveridad"] = new SelectList(CapaLogica_HelpDesk.Severidades.ListSeveridad(), "IdSeveridad", "Severidad");
            ViewData["IdEstado"] = new SelectList(CapaLogica_HelpDesk.Estados.ListEstados(), "IdEstado", "Estado");
            try
            {
                var soport = Soporte.GetOneSoporte(id);
                return View(soport);
            }
            catch (Exception ex)
            {
                Funciones.MostrarError(this, ex);
                return RedirectToAction("RegistroSoporte");
            }
        }

        [HttpPost]
        public ActionResult ModificarSolicitud(Soporte soport)
        {
            //ESTO es usado para llenar LOS DROPDOWNLIST EN LA VISTA! debe estar en el post y en el get
            ViewData["DepartamentId"] = new SelectList(CapaLogica_HelpDesk.Departamentos.ListDeparments(), "IdDeparment", "Departamento");
            ViewData["IdProblem"] = new SelectList(CapaLogica_HelpDesk.Problemas.ListProblems(), "IdProblema", "Descripcion");
            ViewData["IdTipoSolicitud"] = new SelectList(CapaLogica_HelpDesk.Solicitudes.TipoSolicitudes(), "IdSolicitud", "TipoSolicitud");
            ViewData["IdSeveridad"] = new SelectList(CapaLogica_HelpDesk.Severidades.ListSeveridad(), "IdSeveridad", "Severidad");
            ViewData["IdEstado"] = new SelectList(CapaLogica_HelpDesk.Estados.ListEstados(), "IdEstado", "Estado");
            try
            {
                soport.UpdateSoporte();
                Funciones.MostrarSuccess(this, "La Solicitud ha sido actualizada!");
            }
            catch (Exception ex)
            {
                Funciones.MostrarError(this, ex);
                return View(soport);
            }

            return RedirectToAction("DetalleSoporte", new { id = soport.IdSoporte });
        }

        [HttpGet]
        public ActionResult RegistroSoporte()
        {
            ViewData["DepartamentId"] = new SelectList(CapaLogica_HelpDesk.Departamentos.ListDeparments(), "IdDeparment", "Departamento");
            ViewData["IdProblem"] = new SelectList(CapaLogica_HelpDesk.Problemas.ListProblems(), "IdProblema", "Descripcion");
            ViewData["IdTipoSolicitud"] = new SelectList(CapaLogica_HelpDesk.Solicitudes.TipoSolicitudes(), "IdSolicitud", "TipoSolicitud");
            ViewData["IdSeveridad"] = new SelectList(CapaLogica_HelpDesk.Severidades.ListSeveridad(), "IdSeveridad", "Severidad");
            ViewData["IdEstado"] = new SelectList(CapaLogica_HelpDesk.Estados.ListEstados(), "IdEstado", "Estado");
    

            Soporte soporte = new Soporte();


            return View(soporte);
        }
       

        [HttpGet]
        public ActionResult ConsultaMasiva(int? idsoporte = null, string descripcion = null, int? department = null, int? status = null, DateTime? fecha = null, int? idtiposolicitud = null, int? idseveridad = null)
        {
            ViewData["DepartamentId"] = new SelectList(CapaLogica_HelpDesk.Departamentos.ListDeparments(), "IdDeparment", "Departamento");
            ViewData["IdTipoSolicitud"] = new SelectList(CapaLogica_HelpDesk.Solicitudes.TipoSolicitudes(), "IdSolicitud", "TipoSolicitud");
            ViewData["IdSeveridad"] = new SelectList(CapaLogica_HelpDesk.Severidades.ListSeveridad(), "IdSeveridad", "Severidad");
            ViewData["IdEstado"] = new SelectList(CapaLogica_HelpDesk.Estados.ListEstados(), "IdEstado", "Estado");
            ViewData["IdTipoUsuario"] = new SelectList(CapaLogica_HelpDesk.Usuarios.ListUsuarios(), "IdTipoUsuario", "NombreUsuario");

            List<Soporte> soportlist = new List<Soporte>();
            string desc = null;
            if (!string.IsNullOrEmpty(descripcion)) { desc = descripcion; }
            try
            {

                soportlist = Soporte.GetAllSoportes(idsoporte, desc, department, status, fecha, idtiposolicitud, idseveridad);

              
                //Eliminar el querystring
                System.Collections.Specialized.NameValueCollection nm = System.Web.HttpUtility.ParseQueryString(Request.QueryString.ToString());
                nm.Remove("page");
                ViewBag.QueryString = nm.ToString();
            }

            catch (Exception ex)
            {

                Funciones.MostrarError(this, ex);
            }

            return View(soportlist);
        }

        [HttpGet]
        public ActionResult SolicitudesResolver(int? idsoporte = null, string descripcion = null, int? department = null, int? status = null, DateTime? fecha = null, int? idtiposolicitud = null, int? idseveridad = null)
        {
            ViewData["DepartamentId"] = new SelectList(CapaLogica_HelpDesk.Departamentos.ListDeparments(), "IdDeparment", "Departamento");
            ViewData["IdTipoSolicitud"] = new SelectList(CapaLogica_HelpDesk.Solicitudes.TipoSolicitudes(), "IdSolicitud", "TipoSolicitud");
            ViewData["IdSeveridad"] = new SelectList(CapaLogica_HelpDesk.Severidades.ListSeveridad(), "IdSeveridad", "Severidad");
            ViewData["IdEstado"] = new SelectList(CapaLogica_HelpDesk.Estados.ListEstados(), "IdEstado", "Estado");
            ViewData["IdTipoUsuario"] = new SelectList(CapaLogica_HelpDesk.Usuarios.ListUsuarios(), "IdTipoUsuario", "NombreUsuario");

            List<Soporte> soportlist = new List<Soporte>();
            string desc = null;
            if (!string.IsNullOrEmpty(descripcion)) { desc = descripcion; }
            try
            {

                soportlist = Soporte.GetAllSoportes(idsoporte, desc, department, status, fecha, idtiposolicitud, idseveridad);


                //Eliminar el querystring
                System.Collections.Specialized.NameValueCollection nm = System.Web.HttpUtility.ParseQueryString(Request.QueryString.ToString());
                nm.Remove("page");
                ViewBag.QueryString = nm.ToString();
            }

            catch (Exception ex)
            {

                Funciones.MostrarError(this, ex);
            }

            return View(soportlist);
 
        }

        [HttpGet]
        public ActionResult Cerradas(int? idsoporte = null, string descripcion = null, int? department = null, int? status = null, DateTime? fecha = null, int? idtiposolicitud = null, int? idseveridad = null)
        {
            ViewData["DepartamentId"] = new SelectList(CapaLogica_HelpDesk.Departamentos.ListDeparments(), "IdDeparment", "Departamento");
            ViewData["IdTipoSolicitud"] = new SelectList(CapaLogica_HelpDesk.Solicitudes.TipoSolicitudes(), "IdSolicitud", "TipoSolicitud");
            ViewData["IdSeveridad"] = new SelectList(CapaLogica_HelpDesk.Severidades.ListSeveridad(), "IdSeveridad", "Severidad");
            ViewData["IdEstado"] = new SelectList(CapaLogica_HelpDesk.Estados.ListEstados(), "IdEstado", "Estado");
            ViewData["IdTipoUsuario"] = new SelectList(CapaLogica_HelpDesk.Usuarios.ListUsuarios(), "IdTipoUsuario", "NombreUsuario");

            List<Soporte> soportlist = new List<Soporte>();
            string desc = null;
            if (!string.IsNullOrEmpty(descripcion)) { desc = descripcion; }
            try
            {

                soportlist = Soporte.GetAllSoportes(idsoporte, desc, department, status, fecha, idtiposolicitud, idseveridad);


                //Eliminar el querystring
                System.Collections.Specialized.NameValueCollection nm = System.Web.HttpUtility.ParseQueryString(Request.QueryString.ToString());
                nm.Remove("page");
                ViewBag.QueryString = nm.ToString();
            }

            catch (Exception ex)
            {

                Funciones.MostrarError(this, ex);
            }

            return View(soportlist);
        }

        //Asigna un ticket(soporte) a un tecnico(usuario con  id 2 o 3)
        public JsonResult Asignar(int idticket, int idtecnico)
        {
            try
            {
                Soporte.AsginarTicket(idticket, idtecnico,int.Parse(User.Identity.Name));
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        //Cerrar un ticket(soporte) 
        public JsonResult Cerrar(int idticket)
        {
            try
            {
                Soporte.CerrarTicket(idticket);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult EliminarSoporte(int id)
        {
            Soporte soport = new Soporte();
            soport.Delete(id);
            return RedirectToAction("ConsultaMasiva");
        }

    }
}
