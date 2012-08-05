// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NavControllerTests.cs" company="The Advisory Board Company">
//   Copyright 2010-2011
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SportsStore.UnitTests.WebUI.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using Moq;

    using NUnit.Framework;

    using SportsStore.Domain.Abstract;
    using SportsStore.Domain.Entities;
    using SportsStore.WebUI.Controllers;

    [TestFixture]
    public class NavControllerTests
    {

        [Test]
        public void Can_Create_Categories()
        {
            // Arrange:
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
                {
                    new Product {ProductId =1, Name="P1", Category="Apples"},
                    new Product {ProductId =1, Name="P1", Category="Oranges"},
                    new Product {ProductId =1, Name="P1", Category="Apples"},
                    new Product {ProductId =1, Name="P1", Category="Grapes"}
                }.AsQueryable());


            // Arrange:
            NavController controller = new NavController(mock.Object);
            
            // Act: get the set of categories
            var results = controller.Menu().Model as IEnumerable<string>;


            // Assert:
            Assert.IsNotNull(results);
            Assert.AreEqual(results.Count(), 3);

        }

        [Test]
        public void Indicates_Selected_Category()
        {
            // Arrange:
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
                {
                    new Product {ProductId =1, Name="P1", Category="Apples"},
                    new Product {ProductId =4, Name="P1", Category="Oranges"}
                }.AsQueryable());


            // Arrange:
            NavController controller = new NavController(mock.Object);

            // Arrange: define the category to be selected.
            string categoryToSelect = "Apples";

            // Act: get the set of categories
            string result = controller.Menu(categoryToSelect).ViewBag.SelectedCategory;

            // Assert:
            Assert.AreEqual(result,categoryToSelect);
        }
    }
}
