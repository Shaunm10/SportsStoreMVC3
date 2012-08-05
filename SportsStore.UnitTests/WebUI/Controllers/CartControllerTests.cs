// -----------------------------------------------------------------------
// <copyright file="CartControllerTests.cs" company="The Advisory Board Company">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.Web.Mvc;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;

namespace SportsStore.UnitTests.WebUI.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Moq;
    using NUnit.Framework;
    using SportsStore.Domain.Abstract;
    using SportsStore.WebUI.Controllers;

    [TestFixture]
    public class CartControllerTests
    {
        private Mock<IProductRepository> mockProductRepository;

        [SetUp]
        public void Setup()
        {
            this.mockProductRepository = new Mock<IProductRepository>();
        }

        [Test]
        public void Can_Add_To_Cart()
        {
            var productList = new List<Product>
                               {
                                   new Product
                                       {
                                           ProductId = 1,
                                           Name = "P1",
                                           Category = "Apples"
                                           
                                       },
                                       new Product
                                       {
                                           ProductId = 2,
                                           Name = "P2",
                                           Category = "Oranges"
                                       },
                                       new Product
                                       {
                                           ProductId = 3,
                                           Name = "P3",
                                           Category = "Apples"
                                       },
                               };

            // Arrange
            this.mockProductRepository.Setup(m => m.Products).Returns(productList.AsQueryable());

            // Arrange : create cart
            Cart cart = new Cart();

            // Arrange: create the controller
            CartController target = new CartController(this.mockProductRepository.Object);

            // Act
            target.AddToCart(2, null, cart);

            // Assert : the product should now be the the cart.
            Assert.AreEqual(cart.Lines.Count(),1);
            Assert.AreEqual(cart.Lines.ToArray()[0].Product.ProductId,2);
        }

        [Test]
        public void Adding_To_Cart_Goes_To_Cart_Screen()
        {
            var url = "someUrl";
            var productList = new List<Product>
                               {
                                   new Product
                                       {
                                           ProductId = 1,
                                           Name = "P1",
                                           Category = "Apples"
                                           
                                       },
                                       new Product
                                       {
                                           ProductId = 2,
                                           Name = "P2",
                                           Category = "Oranges"
                                       },
                                       new Product
                                       {
                                           ProductId = 3,
                                           Name = "P3",
                                           Category = "Apples"
                                       },
                               };

            // Arrange
            this.mockProductRepository.Setup(m => m.Products).Returns(productList.AsQueryable());

            // Arrange : create cart
            Cart cart = new Cart();

            // Arrange: create the controller
            CartController target = new CartController(this.mockProductRepository.Object);

            // Act
            RedirectToRouteResult result = target.AddToCart(2, url, cart);

            // Assert : the user is redirected to the url specified.
            Assert.AreEqual("Index",result.RouteValues["action"],"Index");
            Assert.AreEqual(url,result.RouteValues["returnUrl"]);
           
        }

        [Test]
        public void Can_View_Cart_Contents()
        {
             var url = "someUrl";

            // Arrange - create a cart
            Cart cart = new Cart();

            // Arrange - create the controller
            CartController controller = new CartController(null);
            
            // Act
            var actionResult = controller.Index(url, cart);

            var model = (CartIndexViewModel) actionResult.Model;

            Assert.AreSame(model.Cart,cart);
            Assert.AreSame(model.ReturnUrl, url);
            
        }

        [Test]
        public void Can_Remove_Item_From_Cart()
        {
            Assert.Fail("This test has not been written yet.");
            
        }

        [TearDown]
        public void TearDown()
        {
            this.mockProductRepository = null;
        }
    }
}
