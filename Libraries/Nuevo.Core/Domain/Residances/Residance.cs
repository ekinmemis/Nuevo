using Core.Domain.ApplicationUsers;

using System;

namespace Nuevo.Core.Domain.Residances
{
    /// <summary>
    /// Defines the <see cref="Residance" />.
    /// </summary>
    public class Residance : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }
     
        /// <summary>
        /// Gets or sets the SquareMeters.
        /// </summary>
        public int SquareMeters { get; set; }

        /// <summary>
        /// Gets or sets the NumbersOfRoom.
        /// </summary>
        public int NumbersOfRoom { get; set; }

        /// <summary>
        /// Gets or sets the BuildingAge.
        /// </summary>
        public int BuildingAge { get; set; }

        /// <summary>
        /// Gets or sets the FloorLocation.
        /// </summary>
        public int FloorLocation { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Swap.
        /// </summary>
        public bool Swap { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether AccessibleByVideoCall.
        /// </summary>
        public bool AccessibleByVideoCall { get; set; }

        /// <summary>
        /// Gets or sets the Dues.
        /// </summary>
        public decimal Dues { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Furnished.
        /// </summary>
        public bool Furnished { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Balcony.
        /// </summary>
        public bool Balcony { get; set; }

        /// <summary>
        /// Gets or sets the NumberOfBathrooms.
        /// </summary>
        public int NumberOfBathrooms { get; set; }

        /// <summary>
        /// Gets or sets the Heating.
        /// </summary>
        public string Heating { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Price.
        /// </summary>
        public decimal Price { get; set; }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// Gets or sets the ApplicationUserId.
        /// </summary>
        public int ApplicationUserId { get; set; }
        /// <summary>
        /// Gets or sets the ApplicationUser.
        /// </summary>
        public ApplicationUser ApplicationUser { get; set; }

        #endregion
    }
}
