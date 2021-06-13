using Nuevo.Core;
using Nuevo.Core.Domain.Residances;
using Nuevo.Services.ApplicationUserServices;
using Nuevo.Services.ResidanceServices;
using Nuevo.Web.Models.ResidanceModels;
using Nuevo.Web.Models.Residances;

using System;
using System.Linq;

namespace Nuevo.Web.Factories.Residances
{
    public class ResidanceModelFactory : IResidanceModelFactory
    {
        private readonly IResidanceService _residanceService;

        public ResidanceModelFactory(IResidanceService residanceService)
        {
            _residanceService = residanceService;
        }

        public virtual ResidanceListModel PrepareResidanceListModel(ResidanceFilteringModel command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            var model = new ResidanceListModel();

            if (command.PageSize == 0) command.PageSize = 1;

            IPagedList<Residance> residances = _residanceService.GetAllResidances(command.PageIndex, command.PageSize, command.Name);

            model.FilterlingContext.LoadPagedList(residances);

            model.Residances = residances
                .Select(x =>
                {
                    var residanceModel = new ResidanceModel();
                    PrepareResidanceModel(residanceModel, x);
                    return residanceModel;
                })
                .ToList();

            return model;
        }

        public virtual void PrepareResidanceModel(ResidanceModel model, Residance residance)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            if (residance == null)
                throw new ArgumentNullException("residance");

            model.Id = residance.Id;
            model.Name = residance.Name;
            model.Description = residance.Description;
            model.Heating = residance.Description;
            model.Price = residance.Price;
            //model.ApplicationUser = residance.ApplicationUser.FirstName + " " + residance.ApplicationUser.FirstName;
        }
    }
}