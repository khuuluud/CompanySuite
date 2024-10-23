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

        //public IActionResult SignIn()
        //{

        //}


        #endregion



    }
}
