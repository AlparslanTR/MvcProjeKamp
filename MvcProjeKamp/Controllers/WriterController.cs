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
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EFWriterDal());
        WriterValidator validationRules = new WriterValidator();
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        public ActionResult Index()
        {
            var writervalues = wm.GetList();
            return View(writervalues);
        }
        [HttpGet]
        public ActionResult WriterAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterAdd(Writer p)
        {
            
            ValidationResult results=validationRules.Validate(p);
            if (results.IsValid)
            {
                wm.WriterAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var x in results.Errors)
                    ModelState.AddModelError(x.PropertyName,x.ErrorMessage);
            }
            return View();
        }
        [HttpGet]
        public ActionResult WriterEdit(int id)
        {
            var writervalue=wm.Get(id);
            return View(writervalue);
        }
        [HttpPost]
        public ActionResult WriterEdit(Writer p)
        {
            ValidationResult results = validationRules.Validate(p);
            if (results.IsValid)
            {
                wm.WriterUpdate(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var x in results.Errors)
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
            }
            return View();
        }
    }
}