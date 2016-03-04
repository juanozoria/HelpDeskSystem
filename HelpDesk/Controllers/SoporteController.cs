using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaLogica_HelpDesk;

namespace HelpDesk.Controllers
{
    [Authorize]
    public class SoporteController : Controller
    {
        [HttpPost]
        public ActionResult RegistroSoporte(Soporte soport)
        {
            //ESTO es usado para llenar LOS DROPDOWNLIST EN LA VISTA! debe estar en el post y en el get
            ViewData["DepartamentId"] = new SelectList(CapaLogica_HelpDesk.Departamentos.ListDeparments(), "IdDeparment", "Departamento");
            ViewData["IdProblem"] = new SelectList(CapaLogica_HelpDesk.Problemas.ListProblems(), "IdProblema", "Descripcion");
            ViewData["IdTipoSolicitud"] = new SelectList(CapaLogica_HelpDesk.Solicitudes.TipoSolicitudes(), "IdSolicitud", "TipoSolicitud");
            ViewData["IdSeveridad"] = new SelectList(CapaLogica_HelpDesk.Severidades.ListSeveridad(),"IdSeveridad","Severidad");
            ViewData["IdEstado"] = new SelectList(CapaLogica_HelpDesk.Estados.ListEstados(), "IdEstado", "Estado");

            try
            {
                if (!string.IsNullOrEmpty(Request["FechaRegistro"].ToString()))
                    soport.FechaRegistro = DateTime.ParseExact(Request["FechaRegistro"].ToString(), "dd-MM-yyyy", null);

                soport.RegistrarSoporte();
                Funciones.MostrarSuccess(this, "Se ha registrado exitosamente!");
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
                return RedirectToAction("NuevoEmpleado");
            }
        }

        [HttpGet]
        public ActionResult ConsultaMasiva(int? idsoporte = null, string descripcion = null, int? department = null,int? status=null, DateTime? fecha=null,int? idtiposolicitud=null,int? idseveridad=null, int? page = 1, int pagesize = 20)
        {
            ViewData["DepartamentId"] = new SelectList(CapaLogica_HelpDesk.Departamentos.ListDeparments(), "IdDeparment", "Departamento");
            ViewData["IdTipoSolicitud"] = new SelectList(CapaLogica_HelpDesk.Solicitudes.TipoSolicitudes(), "IdSolicitud", "TipoSolicitud");
            ViewData["IdSeveridad"] = new SelectList(CapaLogica_HelpDesk.Severidades.ListSeveridad(), "IdSeveridad", "Severidad");
            ViewData["IdEstado"] = new SelectList(CapaLogica_HelpDesk.Estados.ListEstados(), "IdEstado", "Estado");

            List<Soporte> soportlist = new List<Soporte>();
            string desc = null;
            if (!string.IsNullOrEmpty(descripcion)) { desc = descripcion; }
            try
            {

                soportlist = Soporte.GetAllSoportes(idsoporte, desc, department, status, fecha,idtiposolicitud,idseveridad, page, pagesize);
                int ult = Convert.ToInt32(Math.Ceiling((double)soportlist[0].TotalRow / pagesize));

                ViewBag.ult = ult;
                ViewBag.page = page;
                ViewBag.PageSize = pagesize;

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

    }
}
