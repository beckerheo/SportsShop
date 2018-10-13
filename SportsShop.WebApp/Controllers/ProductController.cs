namespace SportsShop.WebApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using SportsShop.Domain.Abstract;
    using SportsShop.Domain.Entities;
    using SportsShop.WebApp.Models;

    public class ProductController : Controller
    {
        private readonly IProductsRepository _repository;

        public int PageSize = 9;

        public ProductController(IProductsRepository productsRepository)
        {
            this._repository = productsRepository;
        }

        public ViewResult List(string category, int page = 1)
        {
            var productList = _repository.Products.Where(p => category == null || p.Category == category);
            ProductsListViewModel model = new ProductsListViewModel()
            {
                Products = productList
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems =productList.Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }

        public FileContentResult GetImage(int productId)
        {
            Product prod = _repository
                    .Products
                    .FirstOrDefault(p => p.ProductId == productId);
            if (prod != null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}