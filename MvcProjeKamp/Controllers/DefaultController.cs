using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        ContentManager cm = new ContentManager(new EFContentDal());
        // GET: Default
        public PartialViewResult Index(int id=1)
        {
            var contentlist = cm.GetListByID(id);
            return PartialView(contentlist);
        }
        public ActionResult Headings()
        {
            var headlist = hm.GetList();
            return View(headlist);
        }
    }
}