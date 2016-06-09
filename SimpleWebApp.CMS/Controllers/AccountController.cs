using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SimpleWebApp.BusinessLogic;
using SimpleWebApp.BusinessLogic.Abstract;
using SimpleWebApp.BusinessLogic.DTO;
using SimpleWebApp.DAL.EF;

namespace SimpleWebApp.CMS.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService =
            new UserService(new UserRepository(new EfDbContext()), new MyMapper());

        public ActionResult Login() =>
            View();


        [HttpPost]
        public ActionResult Login(UserLoginModelDto loginModel)
        {
            if (ModelState.IsValid)
            {
                if (_userService.GetUserLoginModelDto(loginModel.Email, loginModel.Password) != null)
                {
                    FormsAuthentication.SetAuthCookie(loginModel.Email, true);
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", $"There are no user with login: {loginModel.Email} and password");
            }

            return View(loginModel);
        }

        [HttpGet]
        public ActionResult Register() =>
            View();

        [HttpPost]
        public ActionResult Register(UserRegisterModelDto registerModel)
        {
            if (ModelState.IsValid)
            {
                UserLoginModelDto user = _userService.GetUserLoginModelDto(registerModel.Email);

                if (user == null)
                {
                    _userService.Save(registerModel);

                    UserLoginModelDto newUser = _userService.GetUserLoginModelDto(registerModel.Email, registerModel.Password);

                    if (newUser != null)
                    {
                        FormsAuthentication.SetAuthCookie(newUser.Email, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", $"User with {user.Email} already exist.");
                }
            }

            return View(registerModel);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}