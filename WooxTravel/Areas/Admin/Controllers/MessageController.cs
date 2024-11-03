using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WooxTravel.Context;
using WooxTravel.Entities;

namespace WooxTravel.Areas.Admin.Controllers
{
    public class MessageController : Controller
    {
        TravelContext context = new TravelContext();
        public ActionResult Inbox()
        {
            var username = Session["username"];
            ViewBag.username = username;
            var email = context.Admins.Where(x => x.UserName == username).Select(x => x.Email).FirstOrDefault();
            ViewBag.mail = email;

   
            var value = context.Messages.Where(x => x.ReceiverMail == email && x.IsRead == true).ToList();
            return View(value);
        }

        public ActionResult Sendbox()
        {
            var username = Session["username"];
            ViewBag.username = username;
            var email = context.Admins.Where(x => x.UserName == username).Select(x => x.Email).FirstOrDefault();
            ViewBag.mail = email;
            var value = context.Messages.Where(x => x.SenderMail == email).ToList();
            return View(value);
        }

        public ActionResult Trash()
        {
            var username = Session["username"];
            ViewBag.username = username;
            var email = context.Admins.Where(x => x.UserName == username).Select(x => x.Email).FirstOrDefault();
            ViewBag.mail = email;


            var value = context.Messages.Where(x => x.ReceiverMail == email && x.IsRead == false).ToList();
            return View(value);
        }

        public ActionResult Compose()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Compose(Message message)
        {
            var username = Session["username"];
            var email = context.Admins.Where(x => x.UserName == username).Select(x => x.Email).FirstOrDefault();
            message.SenderMail = email;
            message.SendDate = DateTime.Now;
            message.IsRead = false;
            context.Messages.Add(message);
            context.SaveChanges();
            return RedirectToAction("Sendbox","Message", new {area="Admin"});
        }


        public ActionResult DeleteMessage(int id)
        {
            var message = context.Messages.FirstOrDefault(x => x.MessageId == id);
            if (message != null)
            {
                message.IsRead = false; // status değerini 0 yap
                context.SaveChanges();
            }
            return RedirectToAction("Inbox");
        }
    }
}