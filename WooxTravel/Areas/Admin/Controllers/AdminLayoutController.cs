using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WooxTravel.Context;

namespace WooxTravel.Areas.Admin.Controllers
{
    public class AdminLayoutController : Controller
    {
        TravelContext context = new TravelContext();
       
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }  
        public PartialViewResult PartialSidebar()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        } 
        public PartialViewResult PartialThemeSettings()
        {
            return PartialView();
        }
        public PartialViewResult PartialScripts()
        {
            return PartialView();
        } 
        
        public PartialViewResult PartialMessagesInNavbar()
        {

            var username = Session["username"];
            ViewBag.username = username;
            var email = context.Admins.Where(x => x.UserName == username).Select(x => x.Email).FirstOrDefault();
            ViewBag.mail = email;
            var value = context.Messages.Where(x => x.ReceiverMail == email).Take(3).ToList();
            return PartialView(value);
        }   
        
        public PartialViewResult PartialDestinationsInNavbar()
        {

            var value = context.Destinations.OrderByDescending(x=>x.DestinationId).Take(3).ToList();
            return PartialView(value);
        }  
        
        public PartialViewResult AdminInfoInNavbar()
        {

            var username = Session["username"];
            var value = context.Admins.Where(x => x.UserName == username).FirstOrDefault();

            return PartialView(value);
        }
    }
}