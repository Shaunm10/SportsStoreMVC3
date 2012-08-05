// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Cart.cs" company="The Advisory Board Company">
//   Copyright 2010-2011
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SportsStore.Domain.Entities
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Cart
    {
        private readonly List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Product product, int quantity)
        {
            CartLine line = lineCollection
                .Where(p => p.Product.ProductId == product.ProductId)
                .FirstOrDefault();

            // if we don't already have this item in the cart
            if (line == null)
            {
                lineCollection.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        /// <summary>
        /// Removes an item from the cart.
        /// </summary>
        /// <param name="product"></param>
        public void RemoveLine(Product product)
        {
            lineCollection.RemoveAll(l => l.Product.ProductId == product.ProductId);
        }
        public decimal ComputeTotalValue()
        {
            return this.lineCollection.Sum(e => e.Product.Price * e.Quantity);
        }

        public IEnumerable<CartLine> Lines
        {
            get
            {
                return this.lineCollection;
            }
        }

        public void Clear()
        {
            this.lineCollection.Clear();
        }
    }
}
