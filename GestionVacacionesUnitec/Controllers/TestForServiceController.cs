using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using GestionVacacionesUnitec.ServiceReference1;

namespace GestionVacacionesUnitec.Controllers
{
    public class TestForServiceController : Controller
    {
        // GET: TestForService
        public ActionResult Index()
        {
            return View("login");
        }

        // GET: TestForService
        public ActionResult Dashboard()
        {
            return View("Index");
        }

        [HttpPost]
        public void LoginValidation(string email, string password)
        {
            Login(email,password);
        }


        public RedirectToRouteResult Login(string email, string password)
        {
            /*Service1Client test = new Service1Client();
            Usuario user = test.LogInUsuario(email, password);
            test.Close();
            if (user != null)
            {
                Session["Secion"] = user;
                return RedirectToAction("Index", "LoginTest");
            }
            else*/
                return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Login2(string email, string password)
        {
            Service1Client test = new Service1Client();
            int requestStatus = test.LogIn2(email, password);
            Usuario currentUser = test.LogInUsuario(email, password);
            
            Session["Secion2"] = currentUser;
            test.Close();
            
            return Json(new
            {
                status = requestStatus,
                url = "Home/Index"
            });
        }

        
    }
}