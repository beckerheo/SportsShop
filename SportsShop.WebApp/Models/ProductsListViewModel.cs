﻿namespace SportsShop.WebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using SportsShop.Domain.Entities;

    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}