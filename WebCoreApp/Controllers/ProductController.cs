using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;
using WebCoreApp.Application.Interfaces;
using WebCoreApp.Models.ProductViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebCoreApp.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;
        IBillService _billService;
        IProductCategoryService _productCategoryService;
        IAuthorService _authorService;
        IPublisherService _publisherService;
        IConfiguration _configuration;
        public ProductController(IProductService productService, IConfiguration configuration, 
            IBillService billService, IAuthorService authorService, IPublisherService publisherService,
            IProductCategoryService productCategoryService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
            _authorService = authorService;
            _publisherService = publisherService;
            _configuration = configuration;
            _billService = billService;
        }
        [Route("products.html")]
        public IActionResult Index()
        {
            var categories = _productCategoryService.GetAll();
            return View(categories);
        }

        [Route("{alias}-c.{id}.html")]
        public IActionResult Catalog(int id, int? pageSize, string sortBy, int page = 1)
        {
            var catalog = new CatalogViewModel();
            ViewData["BodyClass"] = "shop_grid_full_width_page";
            if (pageSize == null)
                pageSize = _configuration.GetValue<int>("PageSize");

            catalog.PageSize = pageSize;
            catalog.SortType = sortBy;
            catalog.Data = _productService.GetAllPaging(id, string.Empty, page, pageSize.Value);
            catalog.Category = _productCategoryService.GetById(id);

            return View(catalog);
        }


        [Route("search.html")]
        public IActionResult Search(string keyword, int? pageSize, string sortBy, int page = 1)
        {
            var catalog = new SearchResultViewModel();
            ViewData["BodyClass"] = "shop_grid_full_width_page";
            if (pageSize == null)
                pageSize = _configuration.GetValue<int>("PageSize");

            catalog.PageSize = pageSize;
            catalog.SortType = sortBy;
            catalog.Data = _productService.GetAllPaging(null, keyword, page, pageSize.Value);
            catalog.Keyword = keyword;

            return View(catalog);
        }

        [Produces("application/json")]
        [HttpGet]
        public IActionResult GetProductForAutocomplete()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();
                var model = _productService.GetAll().Where(p => p.Name.ToLower().Contains(term) || p.Author.AuthorName.ToLower().Contains(term)).Select(p => p.Name).ToList();
                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }
        }


        [Route("{alias}-p.{id}.html", Name = "ProductDetail")]
        public IActionResult Details(int id)
        {
            var model = new DetailViewModel();
           
            model.Product = _productService.GetById(id);
           
            model.Category = _productCategoryService.GetById(model.Product.CategoryId);
           
          //  model.Author = _authorService.GetById(model.Product.AuthorId);
            //model.Author = vm;
            //model.Publisher = _publisherService.GetById(model.Product.PublisherId);
            model.RelatedProducts = _productService.GetRelatedProducts(id, 9);
            model.UpsellProducts = _productService.GetUpsellProducts(6);
            model.ProductImages = _productService.GetImages(id);
            model.Tags = _productService.GetProductTags(id);
            model.Colors = _billService.GetColors().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            model.Sizes = _billService.GetSizes().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            return View(model);
        }
    }

}
