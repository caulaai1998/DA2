using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreApp.Models.ProductViewModels
{
    public class SearchResultViewModel : CatalogViewModel
    {
        public string Keyword { get; set; }
    }
}
