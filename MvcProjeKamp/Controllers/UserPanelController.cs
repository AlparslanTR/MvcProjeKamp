using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MvcProjeKamp.Controllers
{
   
    public class UserPanelController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        MessageManager mm = new MessageManager(new EFMessageDal());
        MessageValidator mv = new MessageValidator();
        WriterManager wm = new WriterManager(new EFWriterDal());
        WriterValidator validationRules = new WriterValidator();
        ContentManager com = new ContentManager(new EFContentDal());
        Context c = new Context();
        int id;
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult MyProfile(int id=0)
        {
           string p = (string)Session["WriterMail"];
            id = c.writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
            var writerid = wm.Get(id);
            return View(writerid);
        }
        [HttpPost]
        public ActionResult MyProfile(Writer p)
        {
            ValidationResult results = validationRules.Validate(p);
            if (results.IsValid)
            {
                wm.WriterUpdate(p);
                return RedirectToAction("MyProfile");
            }
            else
            {
                foreach (var x in results.Errors)
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
            }
            return View();
        }
        /// <summary>
        /// BAŞLIK KISIMLARI(HEADİNG)
        /// </summary>
        public ActionResult MyHeading(string p,int sayfa=1)
        {
            p = (string)Session["WriterMail"];
            var idinfo=c.writers.Where(x=>x.WriterMail==p).Select(y=>y.WriterId).FirstOrDefault();
            var values = hm.GetList2(idinfo).ToPagedList(sayfa,10);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> category = (from x in cm.GetList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryId.ToString() }).ToList();
            ViewBag.ctg = category;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading p)
        {
            string m = (string)Session["WriterMail"];
            var idinfo = c.writers.Where(x => x.WriterMail == m).Select(y => y.WriterId).FirstOrDefault();
            p.HeadDate = DateTime.Now.ToShortDateString();
            p.WriterId = idinfo;
            p.HeadStatus = true;
            hm.HeadingAdd(p);
            return RedirectToAction("MyHeading");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> category = (from x in cm.GetList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryId.ToString() }).ToList();
            ViewBag.ctg = category;
            var headingvalues = hm.Get(id);
            return View(headingvalues);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("MyHeading");
        }
        public ActionResult DeleteHeading(int id)
        {
            var headingvalue = hm.Get(id);
            headingvalue.HeadStatus = false;
            hm.HeadingDelete(headingvalue);
            return RedirectToAction("MyHeading");
        }
        /// <summary>
        /// BAŞLIK KISIMLARI(HEADİNG)
        /// </summary>
        /////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// MESAJ KISIMLARI(MESSAGE)
        /// </summary>
        public ActionResult MyMessages()
        {
            string p = (string)Session["WriterMail"];
            var messagevalues = mm.GetListInbox(p);
            return View(messagevalues);
        }
        public ActionResult Sendbox()
        {
            string p = (string)Session["WriterMail"];
            var messagevalues2 = mm.GetListSendbox(p);
            return View(messagevalues2);
        }
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
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
        [HttpGet]
        public ActionResult MessageAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MessageAdd(Message p)
        {
            string sender = (string)Session["WriterMail"];
            ValidationResult results = mv.Validate(p);
            if (results.IsValid)
            {
                p.MessageSenderMail = sender;
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
        /// <summary>
        /// MESAJ KISIMLARI(MESSAGE)
        /// </summary>
        /////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Yazı KISIMLARI(Content)
        /// </summary>
        public ActionResult MyContect(string p)
        {
            p=(string)Session["WriterMail"];
            var writerid = c.writers.Where(x => x.WriterMail == p).Select(y=>y.WriterId).FirstOrDefault();
            var contentvalues = com.GetListByWriter(writerid);
            return View(contentvalues);
        }
        [HttpGet]
        public ActionResult AddContect()
        {
            List<SelectListItem> heading = (from x in hm.GetList() select new SelectListItem { Text = x.HeadName, Value = x.HeadId.ToString() }).ToList();
            ViewBag.d = heading;
            return View();
        }
        [HttpPost]
        public ActionResult AddContect(Content p)
        {
            string mail = (string)Session["WriterMail"];
            var writeridinfo=c.writers.Where(x=>x.WriterMail==mail).Select(y=>y.WriterId).FirstOrDefault();
            p.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterId= writeridinfo;
            com.ContentAdd(p);
            return RedirectToAction("MyContect");
        }
    }
}