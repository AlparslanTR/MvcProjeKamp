using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        WriterManager wm = new WriterManager(new EFWriterDal());
        [Authorize]
        public ActionResult Index()
        {
            var headingvalues = hm.GetList();
            return View(headingvalues);
        }
        [HttpGet]
        public ActionResult HeadingAdd()
        {
            // Kategori ve Yazarları droplist ile çekme
            List<SelectListItem> category = (from x in cm.GetList()select new SelectListItem {Text=x.CategoryName,Value=x.CategoryId.ToString() }).ToList();
            ViewBag.ctg=category;
            List<SelectListItem> writer = (from x in wm.GetList() select new SelectListItem { Text = x.WriterName +" "+x.WriterSurName, Value = x.WriterId.ToString() }).ToList();
            ViewBag.wrt = writer;
            return View();
        }
        [HttpPost]
        public ActionResult HeadingAdd(Heading p)
        {
            p.HeadDate=DateTime.Now.ToShortDateString();
            hm.HeadingAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult HeadingEdit(int id)
        {
            List<SelectListItem> category = (from x in cm.GetList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryId.ToString() }).ToList();
            ViewBag.ctg = category;
            List<SelectListItem> writer = (from x in wm.GetList() select new SelectListItem { Text = x.WriterName + " " + x.WriterSurName, Value = x.WriterId.ToString() }).ToList();
            ViewBag.wrt = writer;
            var headingvalues = hm.Get(id);
            return View(headingvalues);
        }
        [HttpPost]
        public ActionResult HeadingEdit(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult HeadingDelete(int id)
        {
            var headingvalue=hm.Get(id);
            headingvalue.HeadStatus = false;
            hm.HeadingDelete(headingvalue);
            return RedirectToAction("Index");
        }
    }
}