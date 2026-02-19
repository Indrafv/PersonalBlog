using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalBlog.Data;
using PersonalBlog.Models;
using PersonalBlog.ViewModel;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace PersonalBlog.Controllers
{
    public class AccessController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public AccessController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            var userFound = await _appDbContext.Users
                .FirstOrDefaultAsync(u => u.name == model.Name);

            if (userFound == null)
            {
                ViewData["Message"] = "Invalid User or Password. Try Again!";
                return View();
            }

            var hasher = new PasswordHasher<object>();

            var result = hasher.VerifyHashedPassword(
                null,
                userFound.password,
                model.Password
            );

            if (result != PasswordVerificationResult.Success)
            {
                ViewData["Message"] = $"Invalid User or Password. Try Again! ";
                return View();
            }

            List<Claim> claims = new List<Claim>()
    {
        new Claim(ClaimTypes.Name, userFound.name)
    };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
            );

            return RedirectToAction("Admin", "Articles");
        }


    }

}
