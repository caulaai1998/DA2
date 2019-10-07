using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreApp.Application.Interfaces;
using WebCoreApp.Application.ViewModels.Product;
using WebCoreApp.Data.Entities;
using WebCoreApp.Infrastructure.Enums;

namespace WebCoreApp.Controllers.Components
{
    public class CategoryMenuViewComponent : ViewComponent
    {

        private IProductCategoryService _productCategoryService;
        private IMemoryCache _memoryCache;
        public CategoryMenuViewComponent(IProductCategoryService productCategoryService, IMemoryCache memoryCache)
        {
            _productCategoryService = productCategoryService;
            _memoryCache = memoryCache;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = _memoryCache.GetOrCreate(CacheKeys.ProductCategories, entry => {
                entry.SlidingExpiration = TimeSpan.FromHours(2);
                return _productCategoryService.GetAll();
            });
            return View(_productCategoryService.GetAll());
        }
    }
}
