namespace SportsShop.WebApp.Infrastructure.Binders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using SportsShop.Domain.Entities;

    public class CartModelBinder : IModelBinder
    {
        /*
         * Binder will be executed automatically when controller is binding model to view and vice versa.
         * Customized binder need to be registered in Global.asax
         */
        private const string sessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // get the Cart from the session
            Cart cart = null;
            if (controllerContext.HttpContext.Session != null)
            {
                cart = (Cart)controllerContext.HttpContext.Session[sessionKey];
            }

            // create the Cart if there wasn't one in the session data
            if (cart == null)
            {
                cart = new Cart();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = cart;
                }
            }

            // return the cart
            return cart;
        }
    }
}