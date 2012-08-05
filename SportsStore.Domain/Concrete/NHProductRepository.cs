// -----------------------------------------------------------------------
// <copyright file="NHProductRepository.cs" company="The Advisory Board Company">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace SportsStore.Domain.Concrete
{
    using System.Linq;
    using NHibernate.Linq;
    using SportsStore.Domain.Abstract;
    using SportsStore.Domain.Entities;
    using SportsStore.Domain.NhibernateSessionFactories;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class NHProductRepository : IProductRepository
    {
        public IQueryable<Product> Products
        {
            get
            {
                return StaticSessionManager.OpenSession().Query<Product>();
            }
        }
    }
}
