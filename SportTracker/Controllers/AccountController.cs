using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportTracker.Areas.Identity.Data;
using System.Threading.Tasks;

namespace IdentityExample.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AspNetUser> _userManager;
        private readonly SignInManager<AspNetUser> _signInManager;

        public AccountController(
            UserManager<AspNetUser> userManager,
            SignInManager<AspNetUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            //login functionality
            var user = await _userManager.FindByNameAsync(username);

            if (user != null)
            {
                //sign in
                var signInResult = await _signInManager.PasswordSignInAsync(user, password, false, false);

                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string username, string password)
        {
            //register functionality

            var user = new AspNetUser
            {
                UserName = username,
                Email = "",
            };

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                ////generation of the email token
                //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                //var link = Url.Action(nameof(VerifyEmail), "Home", new { userId = user.Id, code }, Request.Scheme, Request.Host.ToString());

                //await _emailService.SendAsync(user.Email, "email verify", $"<a href=\"{link}\">Verify Email</a>", true);

                //return RedirectToAction("EmailVerification");
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> VerifyEmail(string userId, string code)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null) return BadRequest();

            var result = await _userManager.ConfirmEmailAsync(user, code);

            if (result.Succeeded)
            {
                return View();
            }

            return BadRequest();
        }

        public IActionResult EmailVerification() => View();

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

        
    }
}