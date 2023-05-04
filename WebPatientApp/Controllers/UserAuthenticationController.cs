using Microsoft.AspNetCore.Mvc;
using WebPatientApp.Models.DTO;
using WebPatientApp.Repositories.Abstract;

namespace MovieStoreMvc.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private IUserAuthenticationService authService;
        public UserAuthenticationController(IUserAuthenticationService authService)
        {
            this.authService = authService;
        }

        //public async Task<IActionResult> Register()
        //{
        //    var model = new RegistrationModel
        //    {
        //        Email = "admin@gmail.com",
        //        Username = "admin",
        //        Name = "Giwbert",
        //        Password = "Admin.123",
        //        PasswordConfirm = "Admin.123",
        //        Role = "Admin"
        //    };
        //    if you want to register with user , Change Role = "User"
        //    var result = await authService.RegisterAsync(model);
        //    return Ok(result.Message);
        //}

        public IActionResult UserList()
        {
            //var data = this._genreService.List().ToList();
            return View();
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await authService.LoginAsync(model);
            if (result.StatusCode == 1)
                return RedirectToAction("Index", "Home");
            else
            {
                TempData["msg"] = "Could not logged in..";
                return RedirectToAction(nameof(Login));
            }
        }

        public async Task<IActionResult> Logout()
        {
           await authService.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }

    }
}
