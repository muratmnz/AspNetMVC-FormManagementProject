using FormManagementProject.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FormManagementProject.Business.Controllers
{
    [AllowAnonymous]
    public class SecurityController : Controller
    {
        UsersEntities db = new UsersEntities();

        // GET: Security
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Users user)
        {
            var userInDb = db.Users.FirstOrDefault(x => x.username == user.username && x.password == user.password);

            if (userInDb != null)
            {
                FormsAuthentication.SetAuthCookie(user.username, false);
                return RedirectToAction("List", "Form");
            }
            else
            {
                ViewBag.Message = "Invalid user. Username or Password is wrong";
                return View();
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}