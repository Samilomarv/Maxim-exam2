using Maxim_exam2.Models.Base;
using Maxim_exam2.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Maxim_exam2.Controllers
{
    public class AccountController : Controller
    {
        UserManager<AppUser> _userManager;
        SignInManager<AppUser> _signInManager;
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserVM loginUserVM)
        {
            var user = await _userManager.FindByEmailAsync(loginUserVM.UsernameorEmail);
            if(user == null)
            {
                user = await _userManager.FindByNameAsync(loginUserVM.UsernameorEmail);
                if(user == null )
                {
                    ModelState.AddModelError("", "username or email ,password invalid");
                    

                }
             
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user,loginUserVM.Password,true);
            if(!result.Succeeded) 
            {
                ModelState.AddModelError("", "Login Or password Wrong");
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
