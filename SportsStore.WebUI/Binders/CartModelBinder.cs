using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private const string cartSessionKey = "shoppingCart";
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // get the cart from session
            var sessionCart = controllerContext.HttpContext.Session[cartSessionKey];

            var cart = sessionCart as Cart;
            
            // create the cart if one isn't already in session.
            if (cart == null)
            {
                cart = new Cart();
                controllerContext.HttpContext.Session[cartSessionKey] = cart;
            }
            // return the cart
            return cart;
        }
    }
}