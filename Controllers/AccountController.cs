using FeedBridge_00.Models.Entities;
using FeedBridge_00.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FeedBridge_00.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;


        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SaveRegister(RegisterUserVM newUser)
        {
            if (ModelState.IsValid)
            {
                // Mapping ( ApplicationUser الي ViewModel من ال Data هنقل ال )

                // 1- Create object of ApplicationUser because put data in this object
                ApplicationUser appUser = new ApplicationUser();

                // 2- put data in ApplicatioNUser
                appUser.UserName = newUser.Name;
                appUser.PasswordHash = newUser.Password;
                appUser.Address = newUser.Town;
                appUser.BirthDate = newUser.Age;
                appUser.Email = newUser.Email;
                appUser.PhoneNumber = newUser.PhoneNumber;

                //Save in database
                var result = await _userManager.CreateAsync(appUser, newUser.Password);
                if (result.Succeeded)
                {
                    // Create Cookie => 
                    await _signInManager.SignInAsync(appUser, isPersistent: false);
                    return RedirectToAction("AllProducts", "Product");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("Error!!", item.Description);
                    }
                }
            }
            return View("Register", newUser);
        }

        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> SaveLogin(LoginUserVM loginUser)
        {
            if (ModelState.IsValid)
            {
                // check found
                var appUser = await _userManager.FindByNameAsync(loginUser.Name);
                if (appUser != null)
                {
                    bool found = await _userManager.CheckPasswordAsync(appUser, loginUser.Password);
                    if (found)
                    {
                        await _signInManager.SignInAsync(appUser, loginUser.RememberMe);
                        return RedirectToAction("GetAll", "Department");
                    }
                }
                ModelState.AddModelError("", "Username or Password wrong");
                // create cookie

            }
            return View("Login", loginUser);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return View("Login");
        }

    }
}
