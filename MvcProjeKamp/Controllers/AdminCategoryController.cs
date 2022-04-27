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
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        [Authorize]
        public ActionResult Index()
        {
            var categoryvalues = cm.GetList();
            return View(categoryvalues);
        }
        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryAdd(Category p)
        {
            CategoryValidator validationRules=new CategoryValidator();
            ValidationResult result=validationRules.Validate(p);
            if (result.IsValid)
            {
                cm.CategoryAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult CategoryDelete(int id)
        {
            var categories = cm.Get(id);
            cm.CategoryDelete(categories);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CategoryUpdate(int id)
        {
            var categories =cm.Get(id);
            return View(categories);
        }
        [HttpPost]
        public ActionResult CategoryUpdate(Category p)
        {
           cm.CategoryUpdate(p);
           return RedirectToAction("Index");
        }
    }
}