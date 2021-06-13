using Core.Domain.ApplicationUsers;

using System.Data.Entity.ModelConfiguration;
namespace Nuevo.Data.Mappings.ApplicationUsers
{

    /// <summary>
    /// Defines the <see cref="ApplicationUserMap" />.
    /// </summary>
    public class ApplicationUserMap : EntityTypeConfiguration<ApplicationUser>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationUserMap"/> class.
        /// </summary>
        public ApplicationUserMap()
        {
            this.ToTable(nameof(ApplicationUser));
        }
    }
}
