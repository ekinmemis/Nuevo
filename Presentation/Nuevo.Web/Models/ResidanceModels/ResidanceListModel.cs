using Nuevo.Web.Models.Residances;

using System.Collections.Generic;

namespace Nuevo.Web.Models.ResidanceModels
{
    public class ResidanceListModel
    {
        public ResidanceListModel()
        {
            FilterlingContext = new ResidanceFilteringModel();
            Residances = new List<ResidanceModel>();
        }

        public ResidanceFilteringModel FilterlingContext { get; set; }
        public IList<ResidanceModel> Residances { get; set; }
    }
}