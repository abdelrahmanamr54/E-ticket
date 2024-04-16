using E_ticket.Models;
using E_ticket.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_ticket.Controllers
{
    public class AccountController : Controller
    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signIn;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signIn)
        {
            this.userManager = userManager;
            this.signIn = signIn;
        }




        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(ApplicationUserVM userVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser() { UserName = userVM.Name, Email = userVM.Email, Address = userVM.Address, PasswordHash = userVM.Password };

                var result = await userManager.CreateAsync(user, userVM.Password);
                if (result.Succeeded)
                {
                    await signIn.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                return View();
            }

            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginVM userVM)
        {
            if (ModelState.IsValid)
            {
                var result = await userManager.FindByNameAsync(userVM.UserName);
                if (result != null)
                {
                    bool check = await userManager.CheckPasswordAsync(result, userVM.Password);

                    if (check)
                    {
                        await signIn.SignInAsync(result, userVM.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError("invalidpw", "invalidpassword");
                }
                else
                {
                    ModelState.AddModelError("invalidU", "invalidusername");
                }

            }
            return View(userVM);

        }
        public async Task<IActionResult> LogOut()
        {
            await signIn.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
