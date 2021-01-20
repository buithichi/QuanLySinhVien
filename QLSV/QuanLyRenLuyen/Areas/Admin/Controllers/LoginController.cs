using Facebook;
using Model.Dao;
using Model.EF;
using QuanLyRenLuyen.Common;
using QuanLyRenLuyen.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace QuanLyRenLuyen.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
      
        // GET: Admin/Login
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, model.PassWord);

                if (result == 2)
                {
                    var user = dao.GetById(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    Session.Add(CommonConstans.USER_SESSION, userSession);
                    var sv = new SinhVienDao();
                    Session.Add("nam", sv.nam());
                    Session.Add("nu", sv.nu());

                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                else ModelState.AddModelError("", "Mật khẩu không đúng.");

            }
            return View("Index");

        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(string UserName, string Passwords,string re_Password)
        {
            var us = new UserDao();
            if (us.kiemtradangky(UserName) == 1)
            {
                if (Passwords == re_Password)
                {
                    us.create(UserName, Passwords);
                    ViewBag.Loi = "Đăng ký thành công";
                    return View();
                }
                else
                {
                    ViewBag.Loi = "Mật khẩu nhập lại không đúng";
                    return View();
                }
            }
            else {
                ViewBag.Loi = "UserName đã tồn tại";
                return View();

            } 

        }



        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Login");
        }


      



    }
}