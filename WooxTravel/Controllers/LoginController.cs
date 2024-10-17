using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WooxTravel.Context;
using WooxTravel.Entities;

namespace WooxTravel.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        TravelContext travelContext = new TravelContext();

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {

            var value = travelContext.Admins.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);
            if (value != null)
            {
                FormsAuthentication.SetAuthCookie(value.UserName, false);
                Session["username"] = value.UserName;
                return RedirectToAction("CategoryList", "Category", new { area = "Admin" });

            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı girildi.");
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Default");
        }
    }
}
