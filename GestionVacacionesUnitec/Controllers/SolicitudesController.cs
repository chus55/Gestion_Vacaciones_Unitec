using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using GestionVacacionesUnitec.ServiceReference1;

namespace GestionVacacionesUnitec.Controllers
{
    public class SolicitudesController : Controller
    {
        // GET: Solicitudes
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CrearSolicitud()
        {
            return View("CrearSolicitud");
        }



        /*public RedirectToRouteResult crearVacacionSolicitud(string talento_humano, string year, string fecha_entrada, 
                                                            string fecha_salida, string dias_solicitados, string fecha_solicitud, 
                                                            string fecha_aprobacion, string estatusID)*/


        [HttpPost]
        public RedirectToRouteResult crearVacacionSolicitud()
        {
            Service1Client test = new Service1Client();
            Usuario currentUser = Session["Secion2"] as Usuario;
            List<tbl_roles> roles = currentUser.ListaDeRoles.ToList<tbl_roles>();
            List<tbl_permisos> permisos = currentUser.ListaDePermisos.ToList<tbl_permisos>();
           // test.agregarVacaciones(talento_humano, year, fecha_entrada, fecha_salida, dias_solicitados, fecha_solicitud, fecha_aprobacion, estatusID);
            test.agregarVacaciones(""+currentUser.Talento_Humano, "1", "2/3/2011", "2/3/2012",
                "11", "3/24/1994", "3/24/1994", "Pendiente");
            test.Close();
            return RedirectToAction("Index", "Home");
        }
    }
}