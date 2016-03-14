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

            ModelState.AddModelError(
                "Password", "您輸入的帳號或密碼錯誤，請重新輸入！");

            foreach (var model in ModelState)
            {
                if (!ModelState.IsValidField(model.Key))
                {
                    object raw = model.Value.Value.RawValue;
                    string str = model.Value.Value.AttemptedValue;

                    foreach (var err in model.Value.Errors)
                    {
                        var errExc = err.Exception;
                        var errMsg = err.ErrorMessage;

                    }
                }
            }

            return View();
        }

        private bool LoginCheck(LoginViewModel login)
        {
            if (login.Email != "test@example.com" )
            {
                ModelState.AddModelError("Email", "帳號輸入錯誤");
            }

            return (
                login.Email == "test@example.com" &&
                login.Password == "123"
                );
        }
    }
}