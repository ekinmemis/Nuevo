using Core.Domain.ApplicationUsers;

using Nuevo.Admin.Models.AccountModels;
using Nuevo.Service.Authentication;
using Nuevo.Services.ApplicationUserServices;

using System.Web.Mvc;

namespace Nuevo.Admin.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAuthenticationService _formsAuthenticationService;
        private readonly IApplicationUserService _applicationUserService;

        public AccountController(IAuthenticationService formsAuthenticationService, IApplicationUserService applicationUserService)
        {
            _formsAuthenticationService = formsAuthenticationService;
            _applicationUserService = applicationUserService;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _applicationUserService.GetApplicationUserByEmail(model.Email);

                if (user == null)
                {
                    ModelState.AddModelError("", "Kullanıcı bulunamadı.");
                    return View();
                }

                if (user.Password != model.Password)
                {
                    ModelState.AddModelError("", "Şifrenizi kontrol ediniz.");
                    return View();
                }

                _formsAuthenticationService.SignIn(user, true);

                return RedirectToAction("Content");
            }

            return View();
        }

        public ActionResult Content()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                //ApplicationUser applicationUser = model.MapTo<RegisterModel, ApplicationUser>();

                ApplicationUser applicationUser = new ApplicationUser()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = "123456"
                };

                //register
                _applicationUserService.InsertApplicationUser(applicationUser);
                //login
                return Login(new LoginModel() { Email = applicationUser.Email, Password = applicationUser.Password });
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            _formsAuthenticationService.SignOut();

            return Redirect("/");
        }

        public ActionResult AccountSettings()
        {
            var authAppUser = _formsAuthenticationService.GetAuthenticatedApplicationUser();
            return View(new AccountSettingsModel
            {
                FirstName = authAppUser.FirstName,
                LastName = authAppUser.LastName,
                Password = authAppUser.Password,
                UserName = authAppUser.UserName,
                Email = authAppUser.Email,
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccountSettings(AccountSettingsModel model)
        {
            if (ModelState.IsValid)
            {
                var authAppUser = _formsAuthenticationService.GetAuthenticatedApplicationUser();
                
                authAppUser.FirstName= model.FirstName;
                authAppUser.LastName = model.LastName;
                authAppUser.Email = model.Email;
                authAppUser.Password= model.Password;

                _applicationUserService.UpdateApplicationUser(authAppUser);

                return RedirectToAction("AccountSettings");
            }

            return RedirectToAction("Content");
        }
    }
}