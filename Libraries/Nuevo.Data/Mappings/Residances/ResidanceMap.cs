namespace Nuevo.Data.Mappings.Residances
{
    using Nuevo.Core.Domain.Residances;

    using System.Data.Entity.ModelConfiguration;

    /// <summary>
    /// Defines the <see cref="ResidanceMap" />.
    /// </summary>
    public class ResidanceMap : EntityTypeConfiguration<Residance>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResidanceMap"/> class.
        /// </summary>
        public ResidanceMap()
        {
            this.ToTable(nameof(Residance));

            this.HasRequired(s => s.ApplicationUser)
                .WithMany(g => g.Residances)
                .HasForeignKey<int>(s => s.ApplicationUserId);
        }
    }
}
