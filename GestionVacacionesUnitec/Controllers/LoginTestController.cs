using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionVacacionesUnitec.ServiceReference1;

namespace GestionVacacionesUnitec.Controllers
{
    public class LoginTestController : Controller
    {
        // GET: LoginTest
        public ActionResult Index()
        {
            //tbl_usuarios user = Session["Secion"] as tbl_usuarios;

            return View("TestIndex", Session["Secion"] as Usuario);
        }
    }
}