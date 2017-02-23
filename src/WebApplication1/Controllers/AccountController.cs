using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KhufuMobile.Models.ViewModels;
using KhufuMobile.Business;
using Microsoft.AspNetCore.Routing;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Authentication;

namespace KhufuMobile.Controllers
{
     
    public class AccountController : Controller
    {

        //[Route("Index")]
        //[HttpGet]
        //[Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            LoginModel login = new LoginModel();
            return View("Login", login);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(LoginModel login)
        {
            var personel = (from p in AppManager.Db.Personel where p.Kod == login.Code && p.Sifre == Convert.ToString(login.Password) select p).FirstOrDefault();
            if (personel != null)
            {
                AppManager.Personel = personel;
                
                authenticate("asd");

                return RedirectToAction("Index", new RouteValueDictionary(
                new { controller = "Account", action = "Index" }));
            }
            else
            {
                login.Warning = "Kullanıcı bilgilerinizi kontrol ediniz.";
                return View("Login", login);
            }
        }


        public void authenticate(string user)
        {
            const string Issuer = "https://contoso.com";
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user, ClaimValueTypes.String, Issuer));
            var userIdentity = new ClaimsIdentity("SuperSecureLogin");
            userIdentity.AddClaims(claims);
            var userPrincipal = new ClaimsPrincipal(userIdentity);

             HttpContext.Authentication.SignInAsync("KhufuCookie", userPrincipal,
                new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                    IsPersistent = false,
                    AllowRefresh = false
                });
        }


    }

}
