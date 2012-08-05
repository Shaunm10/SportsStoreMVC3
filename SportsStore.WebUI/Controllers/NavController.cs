namespace SportsStore.WebUI.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using SportsStore.Domain.Abstract;

    public class NavController : Controller
    {
        private IProductRepository repository;
       
        public NavController(IProductRepository repo)
        {
            this.repository = repo;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = repository.Products
                    .Select(x => x.Category)
                    .OrderBy(x => x).ToList();

            return this.PartialView(categories.Distinct());

        }

        
    }
}
