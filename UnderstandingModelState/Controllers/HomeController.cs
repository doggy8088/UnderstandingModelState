using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UnderstandingModelState.Models;

namespace UnderstandingModelState.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            if (ModelState.IsValid && LoginCheck(login))
            {
                // 輸入驗證成功，所有欄位有效
                FormsAuthentication
                    .RedirectFromLoginPage(login.Email, false);

                return RedirectToAction("Index");
            }

            return View(login);
        }

        private bool LoginCheck(LoginViewModel login)
        {
            return (
                login.Email == "test@example.com" &&
                login.Password == "123"
                );
        }
    }
}