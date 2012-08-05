namespace SportsStore.WebUI.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using SportsStore.Domain.Abstract;
    using SportsStore.WebUI.Models;
    //using log4net;
    using Common.Logging;

    public class ProductController : Controller
    {
        private readonly IProductRepository repository;

        public int PageSize = 4;
        private ILog logger;

        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
            //logger = log4net.LogManager.GetLogger("General");
            logger = LogManager.GetLogger("General");
        }

        public ViewResult List(string category, int page = 1)
        {
            
            ProductsListViewModel viewModel = new ProductsListViewModel
                {
                    Products = this.repository.Products
                    .OrderBy(p => p.ProductId)
                    .Where(p => string.IsNullOrWhiteSpace(category) || p.Category == category)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                    PagingInfo = new PagingInfo
                        {
                            CurrentPage = page,
                            ItemsPerPage = PageSize,
                            TotalItems = category == null ?
                            repository.Products.Count() :
                            repository.Products.Where(x => x.Category == category).Count()
                        },
                    CurrentCategory = category
                };

            return View(viewModel);
        }

        public ViewResult NewPage()
        {
            return this.View();
        }
    }
}
