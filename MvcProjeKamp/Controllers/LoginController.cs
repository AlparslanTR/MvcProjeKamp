using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
namespace MvcProjeKamp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
       
        AdminManager am = new AdminManager(new EFAdminDal());
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var adminuser = am.FirstOrDefault(p);
            if(adminuser != null)
            {
                FormsAuthentication.SetAuthCookie(adminuser.Login,false);
                Session["Login"] = adminuser.Login;
                return RedirectToAction("Index", "Gallery");
            }
            else
            {
                RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(Writer p)
        {
            Context c = new Context();
            var user =c.writers.FirstOrDefault(x=>x.WriterMail == p.WriterMail && x.WriterPass==p.WriterPass);
            if(user != null)
            {
                FormsAuthentication.SetAuthCookie(user.WriterMail,false);
                Session ["WriterMail"]=user.WriterMail;
                return RedirectToAction("MyContect", "UserPanel");
            }
            else
            {
                RedirectToAction("UserLogin");
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("UserLogin", "Login");
        }
        public ActionResult AdminLogout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}