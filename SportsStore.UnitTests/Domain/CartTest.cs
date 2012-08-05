// -----------------------------------------------------------------------
// <copyright file="CartTest.cs" company="The Advisory Board Company">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace SportsStore.UnitTests.Domain
{
    using System.Linq;

    using NUnit.Framework;

    using SportsStore.Domain.Entities;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class CartTest
    {
        [Test]
        public void Can_Add_New_Lines()
        {
            // Arrange - create dummy products
            Product product1 = new Product { ProductId = 1, Name = "P1" };
            Product product2 = new Product { ProductId = 2, Name = "P2" };
            
            // Act - add 2 products to the cart
            Cart c = new Cart();
            c.AddItem(product1, 1);
            c.AddItem(product2, 2);

            //Assert - the items are in the cart.
            Assert.AreEqual(c.Lines.Count(), 2);
            Assert.AreEqual(c.Lines.ToList()[0].Product, product1);
            Assert.AreEqual(c.Lines.ToList()[1].Product, product2);
        }

        [Test]
        public void Can_Add_Quantity_For_Existing_Items()
        {
            // Arrange - create some test products
            Product p1 = new Product { ProductId = 1, Name = "P1" };
            Product p2 = new Product { ProductId = 2, Name = "P2" };

            // Act - create a cart and add the same item to it.
            Cart target = new Cart();
            target.AddItem(p1, 2);
            target.AddItem(p2, 1);
            target.AddItem(p1, 3);

            //Assert -
            Assert.AreEqual(target.Lines.Count(), 2);
            Assert.AreEqual(target.Lines.ToList()[0].Quantity, 5);
            Assert.AreEqual(target.Lines.ToList()[1].Quantity, 1);
        }

        [Test]
        public void Can_Remove_Lines()
        {
            // Arrange - create some test products
            Product p1 = new Product { ProductId = 1, Name = "P1" };
            Product p2 = new Product { ProductId = 2, Name = "P2" };
            Product p3 = new Product { ProductId = 3, Name = "P3" };

            // Act - create a cart and add the same item to it.
            Cart target = new Cart();
            target.AddItem(p1, 4);
            target.AddItem(p2, 1);
            target.AddItem(p1, 3);

            //Assert -
            Assert.AreEqual(target.Lines.Count(), 2);
            Assert.AreEqual(target.Lines.ToList()[0].Quantity, 7);
            Assert.AreEqual(target.Lines.ToList()[1].Quantity, 1);

        }

        [Test]
        public void Calculate_Cart_Total()
        {
            // Arrange - create 2 products
            Product p1 = new Product {ProductId = 1, Name = "P1", Price = 100M};
            Product p2 = new Product {ProductId = 2, Name = "P2", Price = 20M};
            
            // Arrange - create a new cart
            Cart target = new Cart();

            // Act -
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            target.AddItem(p1,3);
            decimal result = target.ComputeTotalValue();

            //Assert -
            Assert.AreEqual(420M,result);
        }

        [Test]
        public void Can_Clear_Contents()
        {
            // Arrange - create 2 products
            Product p1 = new Product { ProductId = 1, Name = "P1", Price = 100M };
            Product p2 = new Product { ProductId = 2, Name = "P2", Price = 20M };

            // Arrange - create a new cart
            Cart target = new Cart();

            // Arrange - add some items
            target.AddItem(p1,1);
            target.AddItem(p2,4);

            // Act -
            target.Clear();

            //Assert -
            Assert.AreEqual(0,target.Lines.Count());
            Assert.AreEqual(0,target.ComputeTotalValue());

        }
    }
}
