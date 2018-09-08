﻿namespace SportsShop.WebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using SportsShop.Domain.Entities;

    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}