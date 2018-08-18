using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsShop.Domain.Abstract;

namespace SportsShop.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepository _repository;

        public ProductController(IProductsRepository productsRepository)
        {
            this._repository = productsRepository;
        }

        public ViewResult List()
        {
            return View(_repository.Products);
        }
    }
}