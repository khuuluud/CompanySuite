using LinkDev.CompanyBase.DAL.Models.Identity;
using LinkDev.CompanyBase.PL.ViewModels.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.CompanyBase.PL.Controllers
{
    public class AccountController : Controller
    {
        #region Services

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        #endregion

        #region Sign Up
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);


            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user is { })
            {

                ModelState.AddModelError(nameof(SignUpViewModel.UserName), "This username is already in use");
                return View(model);
               
            }
            user = new ApplicationUser()
            {
                FName = model.FirstName,
                LName = model.LastName,
                UserName = model.UserName,
                Email = model.Email,
                IsAgree = model.IsAgree
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
                return RedirectToAction(nameof(SignIn));
            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);


            return View(model);
        }

        #endregion

        #region Sign in
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = await _userManager.FindByEmailAsync(model.Email);

            if(user is { })
            {
                var flag = await _userManager.CheckPasswordAsync(user, model.Password);
                if (flag)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, true);
                    if (result.IsNotAllowed)
                        ModelState.AddModelError(string.Empty, "Your account is not confirmed yet!");

                    if (result.IsLockedOut)
                        ModelState.AddModelError(string.Empty, "Your account has been locked!");


                    if (result.Succeeded)
                        return RedirectToAction(nameof(HomeController.Index), "Home");
                }
            }
            return View(model);
        }

        #endregion



    }
}
