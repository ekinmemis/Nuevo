
using Nuevo.Core;
using Nuevo.Core.Domain.Residances;
using Nuevo.Data.EfRepository;
using Nuevo.Service.Authentication;

using System;
using System.Linq;

namespace Nuevo.Services.ResidanceServices
{
    /// <summary>
    /// Defines the <see cref="ResidanceService" />.
    /// </summary>
    public class ResidanceService : IResidanceService
    {
        /// <summary>
        /// Defines the _residanceRepository.
        /// </summary>
        private IRepository<Residance> _residanceRepository;

        public ResidanceService(IRepository<Residance> residanceRepository)
        {
            _residanceRepository = residanceRepository;
        }

        /// <summary>
        /// The GetAllResidances.
        /// </summary>
        /// <param name="pageIndex">The pageIndex<see cref="int"/>.</param>
        /// <param name="pageSize">The pageSize<see cref="int"/>.</param>
        /// <returns>The <see cref="IPagedList{Residance}"/>.</returns>
        public IPagedList<Residance> GetAllResidances(int pageIndex = 0, int pageSize = int.MaxValue, string name = "", int authAppUserId = 0)
        {
            var query = _residanceRepository.Table;

            if (authAppUserId != 0)
                query = query.Where(f => f.ApplicationUserId == authAppUserId);

            if (!string.IsNullOrEmpty(name))
                query = query.Where(f => f.Name.Contains(name));


            query = query.Where(x => x.Deleted == false).OrderBy(o => o.Id);

            var residances = new PagedList<Residance>(query, pageIndex, pageSize);

            return residances;
        }

        /// <summary>
        /// The GetResidanceById.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Residance"/>.</returns>
        public Residance GetResidanceById(int id)
        {
            if (id == 0)
                throw (new ArgumentNullException("parameter missing"));

            var residance = _residanceRepository.GetById(id);

            return residance;
        }

        /// <summary>
        /// The InsertResidance.
        /// </summary>
        /// <param name="residance">The residance<see cref="Residance"/>.</param>
        public void InsertResidance(Residance residance)
        {
            if (residance == null)
                throw (new ArgumentNullException("parameter missing"));

            _residanceRepository.Insert(residance);
        }

        /// <summary>
        /// The UpdateResidance.
        /// </summary>
        /// <param name="residance">The residance<see cref="Residance"/>.</param>
        public void UpdateResidance(Residance residance)
        {
            if (residance == null)
                throw (new ArgumentNullException("parameter missing"));

            _residanceRepository.Update(residance);
        }

        /// <summary>
        /// The DeleteResidance.
        /// </summary>
        /// <param name="residance">The residance<see cref="Residance"/>.</param>
        public void DeleteResidance(Residance residance)
        {
            if (residance == null)
                throw (new ArgumentNullException("parameter missing"));

            _residanceRepository.Delete(residance);
        }
    }
}