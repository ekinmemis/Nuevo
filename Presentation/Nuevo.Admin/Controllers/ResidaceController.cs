using Nuevo.Admin.Configurations;
using Nuevo.Admin.Models.ResidanceModels;
using Nuevo.Core.Domain.Residances;
using Nuevo.Service.Authentication;
using Nuevo.Services.ResidanceServices;

using System;
using System.Web.Mvc;

namespace Nuevo.Admin.Controllers
{
    public class ResidaceController : BaseController
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IResidanceService _residanceService;

        public ResidaceController(IAuthenticationService authenticationService, IResidanceService residanceService)
        {
            _authenticationService = authenticationService;
            _residanceService = residanceService;
        }

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(new ResidanceListModel());
        }

        [HttpPost]
        public ActionResult ResidanceList(ResidanceListModel model)
        {
            var authAppUser = _authenticationService.GetAuthenticatedApplicationUser();
            var residances = _residanceService.GetAllResidances(
                authAppUserId: authAppUser.Id,
                name: model.SearchName,
                pageIndex: model.PageIndex,
                pageSize: model.PageSize);

            return Json(new
            {
                draw = model.Draw,
                recordsFiltered = 0,
                recordsTotal = residances.TotalCount,
                data = residances
            });
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ResidanceModel model)
        {
            if (ModelState.IsValid)
            {
                var appUser = _authenticationService.GetAuthenticatedApplicationUser();

                model.ApplicationUserId = appUser.Id;

                Residance residance = model.MapTo<ResidanceModel, Residance>();

                _residanceService.InsertResidance(residance);

                return RedirectToAction("List");
            }

            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            var residance = _residanceService.GetResidanceById(id);

            if (residance == null || residance.Deleted)
                return RedirectToAction("List");

            ResidanceModel model = residance.MapTo<Residance, ResidanceModel>();

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ResidanceModel model)
        {
            if (ModelState.IsValid)
            {
                var residance = _residanceService.GetResidanceById(model.Id);

                if (residance == null || residance.Deleted)
                    return RedirectToAction("List");

                residance.Name = model.Name;
                residance.SquareMeters = model.SquareMeters;
                residance.NumbersOfRoom = model.NumbersOfRoom;
                residance.BuildingAge = model.BuildingAge;
                residance.FloorLocation = model.FloorLocation;
                residance.Swap = model.Swap;
                residance.AccessibleByVideoCall = model.AccessibleByVideoCall;
                residance.Dues = model.Dues;
                residance.Furnished = model.Furnished;
                residance.Price = model.Price;
                residance.Balcony = model.Balcony;
                residance.NumberOfBathrooms = model.NumberOfBathrooms;
                residance.Heating = model.Heating;
                residance.Description = model.Description;
                residance.ApplicationUserId = model.ApplicationUserId;

                _residanceService.UpdateResidance(residance);

                return RedirectToAction("Edit", new { id = residance.Id });
            }

            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var residance = _residanceService.GetResidanceById(id);

            if (residance == null)
                return Json("ERR");

            residance.Deleted = true;

            _residanceService.UpdateResidance(residance);

            return RedirectToAction("List");
        }
    }
}