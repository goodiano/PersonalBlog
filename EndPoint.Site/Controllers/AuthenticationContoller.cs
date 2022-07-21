using EndPoint.Site.Models.ViewModel.Authentication;
using GoodianoBlog.Application.Interfaces.Contexts;
using GoodianoBlog.Application.Services.Users.Command.ClientSide.LogIn;
using GoodianoBlog.Application.Services.Users.Command.ClientSide.LogIn.ForgetPassword;
using GoodianoBlog.Application.Services.Users.Command.SignUp;
using GoodianoBlog.Common.Dto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EndPoint.Site.Controllers
{
    public class AuthenticationContoller : Controller
    {
        private readonly ISignUpServices _signUpServices;
        private readonly ILogInUserServices _logInUserServices;
        private readonly IForgetPasswordServices _forgetPassword;
        public AuthenticationContoller(ISignUpServices SignUpServices, ILogInUserServices logInUserServices, IForgetPasswordServices forgetPassword)
        {
            _signUpServices = SignUpServices;
            _logInUserServices = logInUserServices;
            _forgetPassword = forgetPassword;
        }

        public IActionResult LogIn(string ReturnUrl = "/")
        {
            ViewBag.url = ReturnUrl;
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(string Email , string Password)
        {
            var result = _logInUserServices.Execute(Email, Password);
            if (result.IsSuccess == true)
            {
                var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, result.Data.Id.ToString()),
                new Claim(ClaimTypes.Email, Email),
                new Claim(ClaimTypes.Name, result.Data.UserName),
                new Claim(ClaimTypes.Role, "Customer"),
            };

                foreach (var item in result.Data.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, item));
                }

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.Now.AddDays(5)
                };
                HttpContext.SignInAsync(principal, properties);

            }
            return Json(result);
        }
         ///TODo: forget password complete whenever finish project
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgetPassword(string email)
        {
            return Json(_forgetPassword.Execute(email));
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(SignUpViewModel request)
        {
            //if (User.Identity.IsAuthenticated == true)
            //{
            //    return Json(new ResultDto { IsSuccess = false, Message = "شما قبلا ثبت نام کردید" });
            //}
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var user = _signUpServices.Execute(new RequestSignUpUserDto
            {
                UserName = request.UserName,
                Email = request.Email,
                PhonNumber = request.PhonNumber,
                Password = request.Password,
                RePassword = request.RePassword,
                Roles = new List<RoleUserDto>
                {
                     new RoleUserDto(){Id = 2}
                }
            });

            if (user.IsSuccess == true)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Data.UserId.ToString()),
                    new Claim(ClaimTypes.Name , request.UserName),
                    new Claim(ClaimTypes.Email , request.Email),
                    new Claim(ClaimTypes.MobilePhone , request.PhonNumber)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true
                };
                HttpContext.SignInAsync(principal, properties);
            }

            return Json(user);
        }


        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }
    }
}
