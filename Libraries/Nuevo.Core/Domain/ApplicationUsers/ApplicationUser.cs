using Nuevo.Core;
using Nuevo.Core.Domain.Residances;

using System.Collections.Generic;

namespace Core.Domain.ApplicationUsers
{
    /// <summary>
    /// Defines the <see cref="ApplicationUser" />.
    /// </summary>
    public partial class ApplicationUser : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the FirstName.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the LastName.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the UserName.
        /// </summary>
        public string UserName { get; set; }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// Defines the _residances.
        /// </summary>
        private ICollection<Residance> _residances;

        /// <summary>
        /// Gets or sets the Residances.
        /// </summary>
        public virtual ICollection<Residance> Residances { get => _residances ?? (_residances = new List<Residance>()); protected set => _residances = value; }

        #endregion
    }
}
