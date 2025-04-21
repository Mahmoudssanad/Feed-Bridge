using FeedBridge_00.Models.Entities;
using FeedBridge_00.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        //[HttpPost]
        //public async Task<IActionResult> SaveRegister(RegisterUserVM newUser)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Mapping ( ApplicationUser الي ViewModel من ال Data هنقل ال )

        //        // 1- Create object of ApplicationUser because put data in this object
        //        ApplicationUser appUser = new ApplicationUser();

        //        // 2- put data in ApplicatioNUser
        //        appUser.UserName = newUser.Name;
        //        appUser.PasswordHash = newUser.Password;
        //        appUser.Address = newUser.Town;
        //        appUser.BirthDate = newUser.Age;
        //        appUser.Email = newUser.Email;
        //        appUser.PhoneNumber = newUser.PhoneNumber;

        //        //Save in database
        //        var result = await _userManager.CreateAsync(appUser, newUser.Password);
        //        if (result.Succeeded)
        //        {
        //            // Create Cookie => 
        //            await _signInManager.SignInAsync(appUser, isPersistent: false);
        //            return RedirectToAction("AllProducts", "Product");
        //        }
        //        else
        //        {
        //            foreach (var item in result.Errors)
        //            {
        //                ModelState.AddModelError("Error!!", item.Description);
        //            }
        //        }
        //    }
        //    return View("Register", newUser);
        //}


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveRegister(RegisterUserVM newUser)
        {
            if (ModelState.IsValid)
            {
                // Mapping from RegisterViewModel to ApplicationUser
                ApplicationUser appUser = new ApplicationUser
                {
                    UserName = newUser.Name,
                    Email = newUser.Email,
                    Phone = newUser.PhoneNumber,
                    Address = $"{newUser.Town}, {newUser.Country}", // Combine town and country
                    BirthDate = newUser.BirthDate // Convert age to birth date
                                                  // Add any additional properties your ApplicationUser might have
                };

                // Save in database
                var result = await _userManager.CreateAsync(appUser, newUser.Password);

                if (result.Succeeded)
                {
                    // Optionally add user to a default role
                    // await _userManager.AddToRoleAsync(appUser, "User");

                    // Create authentication cookie
                    await _signInManager.SignInAsync(appUser, isPersistent: false);
                    return RedirectToAction("AllProducts", "Product");
                }

                // If user creation failed, add errors to ModelState
                foreach (var error in result.Errors)
                {
                    // Map Identity errors to appropriate fields
                    if (error.Code.Contains("Password"))
                    {
                        ModelState.AddModelError(nameof(RegisterUserVM.Password), error.Description);
                    }
                    else if (error.Code.Contains("Email"))
                    {
                        ModelState.AddModelError(nameof(RegisterUserVM.Email), error.Description);
                    }
                    else if (error.Code.Contains("UserName"))
                    {
                        ModelState.AddModelError(nameof(RegisterUserVM.Name), error.Description);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            // If we got this far, something failed, redisplay form with errors
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
                // Use FirstOrDefaultAsync instead of FindByEmailAsync
                var appUser = await _userManager.Users
                    .FirstOrDefaultAsync(u => u.Email == loginUser.Email);

                if (appUser != null)
                {
                    bool found = await _userManager.CheckPasswordAsync(appUser, loginUser.Password);
                    if (found)
                    {
                        await _signInManager.SignInAsync(appUser, loginUser.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                }

                ModelState.AddModelError("", "Username or Password wrong");
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
