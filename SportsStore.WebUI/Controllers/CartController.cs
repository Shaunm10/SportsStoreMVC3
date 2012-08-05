using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository productRepository;
        //
        // GET: /Cart/

        /// <summary>
        /// Creates and instance of the product Cart Controller class.
        /// </summary>
        /// <param name="productRepository"></param>
        public CartController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

       
        public ViewResult Index(string returnUrl, Cart cart)
        {
            var cartIndexModel = new CartIndexViewModel
                                     {
                                         Cart = cart,
                                         ReturnUrl = returnUrl
                                     };
            return this.View(cartIndexModel);
        }

        [HttpPost]
        public RedirectToRouteResult AddToCart(int? productId, string returnUrl, Cart cart)
        {
            if (productId.HasValue)
            { 
                Product product = this.productRepository.Products
                    .FirstOrDefault(p => p.ProductId == productId.Value);

                if (product != null)
                {
                    cart.AddItem(product,1);
                }
            }
            return RedirectToAction("Index", new {returnUrl});
        }
        
        [HttpPost]
        public RedirectToRouteResult RemoveFromCart(int? productId, string returnUrl, Cart cart)
        {
            if (productId.HasValue)
            { 
                Product product = this.productRepository.Products
                    .FirstOrDefault(p => p.ProductId == productId.Value);

                if (product != null)
                {
                    cart.RemoveLine(product);
                }
            }
            return this.RedirectToAction("Index", new {returnUrl});
        }

        public ViewResult Summary(Cart cart)
        {
            return this.View("Summary",cart);
        }

        public ViewResult Checkout()
        {
            return this.View(new ShippingDetails());
        }
    }
}
