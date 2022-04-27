using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contect
        ContactManager cm= new ContactManager(new EFContactDal());
        ContactValidator cv = new ContactValidator();
        [Authorize]
        public ActionResult Index()
        {
            var contactvalues = cm.GetList();
            return View(contactvalues);
        }
        public ActionResult ContactDetails(int id)
        {
            var contactvalues =cm.Get(id);
            return View(contactvalues); 
        }
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
    }
}