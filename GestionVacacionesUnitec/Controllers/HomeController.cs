using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using GestionVacacionesUnitec.ServiceReference1;

namespace GestionVacacionesUnitec.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View("DashBoard");
        }

        [HttpPost]
        public ActionResult getSession()
        {
            Usuario currentUser = Session["Secion2"] as Usuario;
            List<tbl_roles> roles = currentUser.ListaDeRoles.ToList<tbl_roles>();
            List<tbl_permisos> permisos = currentUser.ListaDePermisos.ToList<tbl_permisos>();
            string serializedRoles = "";
            string serializedPermissions = "";

            for (int c = 0; c < roles.Count; c++)
                serializedRoles += 
                    (c > 0 ) ? 
                    "~" + roles.ElementAt(c).rolesid.ToString() : 
                    roles.ElementAt(c).rolesid.ToString();

            for (int c = 0; c < permisos.Count; c++)
                serializedPermissions +=
                    (c > 0) ?
                    "~" + permisos.ElementAt(c).permisosid.ToString() :
                    permisos.ElementAt(c).permisosid.ToString();

                return Json(new
                {
                    name = currentUser.Primer_Nombre,
                    lastName = currentUser.Primer_Apellido,
                    email = currentUser.Email,
                    talentoHumano = currentUser.Talento_Humano,
                    roles = serializedRoles,
                    permisos = serializedPermissions
                });
        }

      [HttpPost]
        public ActionResult getRolesPorUsuario(string talento_humano)
        {
            Service1Client test = new Service1Client();
            //tbl_roles[] _roles = test.ListaDeRolesPorUsuario(talento_humano);
            test.Close();
            int numero;

            

            return Json(new
            {
                roles = "place holder"
            });
            
        }
    }
}