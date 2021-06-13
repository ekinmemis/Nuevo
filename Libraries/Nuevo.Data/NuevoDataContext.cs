using Core.Domain.ApplicationUsers;

using Nuevo.Core.Domain.Residances;
using Nuevo.Data.Mappings.ApplicationUsers;
using Nuevo.Data.Mappings.Residances;

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Nuevo.Data
{
    /// <summary>
    /// Defines the <see cref="NuevoDataContext" />.
    /// </summary>
    public class NuevoDataContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NuevoDataContext"/> class.
        /// </summary>
        public NuevoDataContext() : base("name=NuevoDataContext")
        {
        }

        /// <summary>
        /// The OnModelCreating.
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder<see cref="DbModelBuilder"/>.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new ApplicationUserMap());
            modelBuilder.Configurations.Add(new ResidanceMap());
        }

        /// <summary>
        /// Gets or sets the ApplicationUser.
        /// </summary>
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        /// <summary>
        /// Gets or sets the Residance.
        /// </summary>
        public DbSet<Residance> Residance { get; set; }
    }
}
