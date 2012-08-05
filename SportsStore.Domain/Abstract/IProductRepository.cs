// -----------------------------------------------------------------------
// <copyright file="IProductsRepository.cs" company="The Advisory Board Company">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using SportsStore.Domain.Entities;
namespace SportsStore.Domain.Abstract
{
    using System.Linq;

    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}
