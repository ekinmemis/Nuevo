using Nuevo.Services.ApplicationUserServices;
using Nuevo.Services.ResidanceServices;
using Nuevo.Web.Factories.Residances;
using Nuevo.Web.Models.ResidanceModels;
using Nuevo.Web.Models.Residances;

using System.Web.Mvc;

namespace Nuevo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IResidanceService _residanceService;
        private readonly IResidanceModelFactory _residanceModelFactory;
        private readonly IApplicationUserService _applicationUserService;

        public HomeController(IResidanceService residanceService, IResidanceModelFactory residanceModelFactory, IApplicationUserService applicationUserService)
        {
            _residanceService = residanceService;
            _residanceModelFactory = residanceModelFactory;
            _applicationUserService = applicationUserService;
        }

        public ActionResult Index(ResidanceFilteringModel command)
        {
            var model = _residanceModelFactory.PrepareResidanceListModel(command);
            return View(model);
        }

        public ActionResult SinglePage(int? id)
        {
            var residance = _residanceService.GetResidanceById((int)id);
            var appUser = _applicationUserService.GetApplicationUserById(residance.ApplicationUserId);
            return View(new ResidanceModel()
            {
                Description = residance.Description,
                Heating = residance.Heating,
                Name = residance.Name,
                Id = residance.Id,
                ApplicationUser = appUser.FirstName + " " + appUser.LastName
            });
        }
    }
}