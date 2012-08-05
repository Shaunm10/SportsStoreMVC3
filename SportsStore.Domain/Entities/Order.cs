// -----------------------------------------------------------------------
// <copyright file="Order.cs" company="The Advisory Board Company">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace SportsStore.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Order
    {
        public int OrderId { get; set; }
        public ShippingDetails ShippingDetails { get; set; }
        public virtual IList<OrderDetail> OrderDetails { get; set; }
    }
}
