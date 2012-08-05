// -----------------------------------------------------------------------
// <copyright file="IOrderProcessor.cs" company="The Advisory Board Company">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------



namespace SportsStore.Domain.Abstract
{
    using SportsStore.Domain.Entities;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, ShippingDetails shippingDetails);
    }
}
