using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EFMessageDal());
        MessageValidator mv = new MessageValidator();
        [Authorize]
        public ActionResult Inbox(string p)
        {
            var messagevalues = mm.GetListInbox(p);
            return View(messagevalues);
        }
        public ActionResult Sendbox(string p)
        {
            var messagevalues2 = mm.GetListSendbox(p);
            return View(messagevalues2);
        }
        [HttpGet]
        public ActionResult MessageAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MessageAdd(Message p)
        {
            ValidationResult results = mv.Validate(p);
            if (results.IsValid)
            {
                p.MessageDate = DateTime.Parse(DateTime.Now.ToString());
                mm.MessageAdd(p);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var x in results.Errors)
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
            }
            return View();
        }
        public ActionResult ReadMail(int id)
        {
            var contactvalues = mm.Get(id);
            return View(contactvalues);
        }
        public ActionResult SendReadMail(int id)
        {
            var contactvalues = mm.Get(id);
            return View(contactvalues);
        }
    }
}