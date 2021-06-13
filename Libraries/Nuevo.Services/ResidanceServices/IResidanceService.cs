
using Nuevo.Core;
using Nuevo.Core.Domain.Residances;

namespace Nuevo.Services.ResidanceServices
{
    /// <summary>
    /// Defines the <see cref="IResidanceService" />.
    /// </summary>
    public interface IResidanceService
    {
        /// <summary>
        /// The GetAllResidances.
        /// </summary>
        /// <param name="pageIndex">The pageIndex<see cref="int"/>.</param>
        /// <param name="pageSize">The pageSize<see cref="int"/>.</param>
        /// <returns>The <see cref="IPagedList{Residance}"/>.</returns>
        IPagedList<Residance> GetAllResidances(int pageIndex = 0, int pageSize = int.MaxValue, string name = "",int authAppUserId = 0);

        /// <summary>
        /// The GetResidanceById.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Residance"/>.</returns>
        Residance GetResidanceById(int id);

        /// <summary>
        /// The InsertResidance.
        /// </summary>
        /// <param name="applicationUser">The applicationUser<see cref="Residance"/>.</param>
        void InsertResidance(Residance applicationUser);

        /// <summary>
        /// The UpdateResidance.
        /// </summary>
        /// <param name="applicationUser">The applicationUser<see cref="Residance"/>.</param>
        void UpdateResidance(Residance applicationUser);

        /// <summary>
        /// The DeleteResidance.
        /// </summary>
        /// <param name="applicationUser">The applicationUser<see cref="Residance"/>.</param>
        void DeleteResidance(Residance applicationUser);
    }
}
