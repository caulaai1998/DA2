﻿using System;
using System.Collections.Generic;
using System.Text;
using WebCoreApp.Application.ViewModels.Product;

namespace WebCoreApp.Application.Interfaces
{
    public class ProductImageViewModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public ProductViewModel Product { get; set; }

        public string Path { get; set; }

        public string Caption { get; set; }
    }
}
