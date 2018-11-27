using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AnketMerkezi.Data.ORM.Entities;
using AnketMerkezi.UI.Models.VMs.User;
using AnketMerkezi.UI.Models.Types;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace AnketMerkezi.UI.Controllers
{
    [AllowAnonymous]
    public class UserController : BaseController
    {
        public int UsernameControl(string username)
        {
            User user = Service.User.FirstOrDefault(x => x.Username == username);
            if (user == null)
                return 0;
            else
                return 1;
        }

        public int EmailControl(string email)
        {
            UserDetail user = Service.UserDetail.FirstOrDefault(x => x.Email == email);
            if (user == null)
                return 0;
            else
                return 1;
        }

        public IActionResult Register() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public int Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                User user = Service.User.FirstOrDefault(x => x.Username == model.Username);
                UserDetail userDetail = Service.UserDetail.FirstOrDefault(x => x.Email == model.Email);
                if (user == null && userDetail == null)
                {
                    user = Service.User.Insert(new User { AccountType = (int)EnumUserType.Normal, Username = model.Username, Password = model.Password });
                    Service.UserDetail.Insert(new UserDetail { Email = model.Email, Name = model.Name, PhoneNumber = model.PhoneNumber, Surname = model.Surname, UserID = user.ID });
                    return 1;
                }
                else
                    return 0;
            }
            else
                return 0;
        }

        public IActionResult Login() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                User user = Service.User.FirstOrDefault(x => x.Username == model.Username && x.Password == model.Password);
                if (user != null)
                {
                    var claims = new List<Claim>
                     {
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Role, user.AccountType.ToString()),
                        new Claim(ClaimTypes.NameIdentifier, user.ID.ToString())
                    };

                    var userIdentity = new ClaimsIdentity(claims, "login");

                    await HttpContext.SignInAsync(new ClaimsPrincipal(userIdentity));

                    return RedirectToAction("Index", "Panel");
                }
                else
                    ViewBag.msg = "Kullanıcı adınız veya şifreniz yanlıştır.";
            }
            else
                ViewBag.msg = "Lütfen geçerli veri girişi yapınız.";
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}