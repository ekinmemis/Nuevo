using System;
using System.ComponentModel.DataAnnotations;

namespace Nuevo.Web.Models.ResidanceModels
{
    public class ResidanceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Heating { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ApplicationUser { get; set; }
    }
}