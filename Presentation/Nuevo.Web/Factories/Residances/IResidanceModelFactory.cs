using Nuevo.Core.Domain.Residances;
using Nuevo.Web.Models.ResidanceModels;
using Nuevo.Web.Models.Residances;

namespace Nuevo.Web.Factories.Residances
{
    public interface IResidanceModelFactory
    {
        ResidanceListModel PrepareResidanceListModel(ResidanceFilteringModel command);
        void PrepareResidanceModel(ResidanceModel model, Residance residance);
    }
}