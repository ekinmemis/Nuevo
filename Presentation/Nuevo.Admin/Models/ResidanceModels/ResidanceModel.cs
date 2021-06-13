using System;
using System.ComponentModel.DataAnnotations;

namespace Nuevo.Admin.Models.ResidanceModels
{
    public class ResidanceModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Heating { get; set; }
        [Required]
        public string Description { get; set; }
        
        [Required]
        public int SquareMeters { get; set; }
        [Required]
        public int NumbersOfRoom { get; set; }
        [Required]
        public int BuildingAge { get; set; }
        [Required]
        public int FloorLocation { get; set; }
        [Required]
        public int NumberOfBathrooms { get; set; }
        [Required]
        public decimal Dues { get; set; }
        [Required]
        public decimal Price { get; set; }


        public bool Swap { get; set; }
        public bool AccessibleByVideoCall { get; set; }
        public bool Furnished { get; set; }
        public bool Balcony { get; set; }

        public int ApplicationUserId { get; set; }
    }
}