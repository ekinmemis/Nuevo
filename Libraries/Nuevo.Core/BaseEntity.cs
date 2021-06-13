namespace Nuevo.Core
{
    /// <summary>
    /// Defines the <see cref="BaseEntity" />.
    /// </summary>
    public class BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Deleted.
        /// </summary>
        public bool Deleted { get; set; }

        #endregion
    }
}
