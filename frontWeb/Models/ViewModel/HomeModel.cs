﻿using System;
using System.Collections.Generic;

namespace frontWeb.Models.ViewModel
{
    public class HomeModel
    {
        public HomeModel()
        {
            //ProductList = new List<Product>();
            Categories = new List<Category>();
        }

        //public List<Product> ProductList { get; set; }
        public List<Category> Categories { get; set; }

    }
}
