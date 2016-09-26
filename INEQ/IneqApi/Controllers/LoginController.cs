using IneqApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace IneqApi.Controllers
{
    public class LoginController : ApiController
    {
        private IneqDbContext db = new IneqDbContext();

        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View(db.User.ToList());
        }

        private ActionResult View(List<IneqApi.Models.User> list)
        {
            throw new NotImplementedException();
        }

        private ActionResult View(List<IneqApi.Areas.HelpPage.Models.User> list)
        {
            throw new NotImplementedException();
        }

        public ActionResult Login()
        {
            return View();
        }

        private ActionResult View()
        {
            throw new NotImplementedException();
        }

        public ActionResult Login(User user)
        {
            var e = db.User.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault();

            if (e != null)
            {
                e.Id.ToString();
                e.Username.ToString();
                return RedirectToAction("LoggedIn");
            }
            else
            {
                ModelState.AddModelError("", "El usuario o la contraseña estan equivocados. Confirme si los datos estan correctos.");
            }
            return View();


        }

        private ActionResult RedirectToAction(string p)
        {
            throw new NotImplementedException();
        }

        public ActionResult LoggedIn(int Id)
        {
            if (Id != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}
