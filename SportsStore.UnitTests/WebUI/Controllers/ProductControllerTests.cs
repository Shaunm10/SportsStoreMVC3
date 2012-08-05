// -----------------------------------------------------------------------
// <copyright file="ProductsControllerTests.cs" company="The Advisory Board Company">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace SportsStore.UnitTests.WebUI.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using Moq;
    using NUnit.Framework;
    using SportsStore.Domain.Abstract;
    using SportsStore.Domain.Entities;
    using SportsStore.WebUI.Controllers;
    using SportsStore.WebUI.Models;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class ProductControllerTests
    {
      
        [Test]
        public void Can_List_Paginate()
        {
            // arrange
            // create mock repository
            var productRepository = new Mock<IProductRepository>();
            productRepository.Setup(m => m.Products).Returns(new Product[]
                {
                    new Product {ProductId = 1, Name = "P1"},
                    new Product {ProductId = 2, Name = "P2"},
                    new Product {ProductId = 3, Name = "P3"},
                    new Product {ProductId = 4, Name = "P4"},
                    new Product {ProductId = 5, Name = "P5"}
              }.AsQueryable());

            //Arrange: create a controller and make the page size 3 items.
            ProductController controller = new ProductController(productRepository.Object);
            controller.PageSize = 3;

            // act 
            var actionResult = controller.List(null, 2);

            // assert
            var productsListViewModel = actionResult.Model as ProductsListViewModel;

            Assert.IsNotNull(productsListViewModel);
            Assert.IsTrue(productsListViewModel.Products.Count() == 2);
            Assert.AreEqual(productsListViewModel.Products.ToArray()[0].Name, "P4");
            Assert.AreEqual(productsListViewModel.Products.ToArray()[1].Name, "P5");

        }

        [Test]
        public void Can_List_Filter_Products()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
                {
                  new Product { ProductId = 1, Name="P1",Category ="Cat1"},
                  new Product { ProductId = 2, Name="P2",Category ="Cat2"},
                  new Product { ProductId = 3, Name="P3",Category ="Cat1"},
                  new Product { ProductId = 4, Name="P4",Category ="Cat2"},
                  new Product { ProductId = 5, Name="P5",Category ="Cat3"}
                }.AsQueryable());

            // create a controller and make the page size 3 items
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            // Act
            Product[] results = ((ProductsListViewModel)controller.List("Cat2", 1).Model).Products.ToArray();

            // Assert
            Assert.AreEqual(results.Length, 2);
            Assert.IsTrue(results[0].Name == "P2" && results[0].Category == "Cat2");
            Assert.IsTrue(results[1].Name == "P4" && results[1].Category == "Cat2");

        }

        [Test]
        public void Can_List_Send_Pagination_View_Model()
        {
            // Arrange
            Mock<IProductRepository> mockRepository = new Mock<IProductRepository>();
            mockRepository.Setup(m => m.Products).Returns(new Product[]
                {
                    new Product{ProductId = 1, Name="P1"},
                    new Product{ProductId = 2, Name="P2"},
                    new Product{ProductId = 3, Name="P3"},
                    new Product{ProductId = 3, Name="P4"},
                    new Product{ProductId = 5, Name="P5"}
                }.AsQueryable());

            ProductController controller = new ProductController(mockRepository.Object);
            controller.PageSize = 3;

            // Act
            var result = controller.List(null, 2).Model;

            ProductsListViewModel productsListViewModelResult = result as ProductsListViewModel;

            // Assert
            Assert.IsNotNull(productsListViewModelResult);
            PagingInfo pagingInfo = productsListViewModelResult.PagingInfo;
            Assert.AreEqual(pagingInfo.CurrentPage, 2);
            Assert.AreEqual(pagingInfo.ItemsPerPage, 3);
            Assert.AreEqual(pagingInfo.TotalItems, 5);
            Assert.AreEqual(pagingInfo.TotalPages, 2);
        }

        [Test]
        public void Generate_Category_Specific_Product_Count()
        {
            // Arrange:
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
                {
                    new Product {ProductId = 1, Name = "P1", Category = "Cat1"},
                    new Product {ProductId = 2, Name = "P2", Category = "Cat2"},
                    new Product {ProductId = 3, Name = "P3", Category = "Cat1"},
                    new Product {ProductId = 4, Name = "P4", Category = "Cat2"},
                    new Product {ProductId = 5, Name = "P5", Category = "Cat3"}
        }.AsQueryable());
           
            // Arrange - create a controller and make the page size 3 items.
            ProductController target = new ProductController(mock.Object);
            target.PageSize = 3;

            // Action - test the product count for different categories.
            int res1 = ((ProductsListViewModel)target.List("Cat1").Model).PagingInfo.TotalItems;
            int res2 = ((ProductsListViewModel)target.List("Cat2").Model).PagingInfo.TotalItems;
            int res3 = ((ProductsListViewModel)target.List("Cat3").Model).PagingInfo.TotalItems;
            int resAll = ((ProductsListViewModel)target.List(null).Model).PagingInfo.TotalItems;
           
            // Assert
            Assert.AreEqual(res1, 2);
            Assert.AreEqual(res2, 2);
            Assert.AreEqual(res3, 1);
            Assert.AreEqual(resAll, 5);

        }

    }
}
