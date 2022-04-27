using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class GalleryController : Controller
    {
        ImagefileManager im = new ImagefileManager(new EFImagefileDal());
        // GET: Gallery
        [Authorize]
        public ActionResult Index()
        {
            var imagevalues = im.GetList();
            return View(imagevalues);
        }
    }
}