using System;
using System.Collections.Generic;
using System.Text;
using WebCoreApp.Application.ViewModels.Product;
using WebCoreApp.Data.Enums;

namespace WebCoreApp.Application.ViewModels
{
    public class PublisherViewModel
    {
        public int Id { get; set; }

        public string PublisherName { get; set; }

        public string Description { get; set; }

        public int? ParentId { get; set; }

        public int? HomeOrder { get; set; }
        public bool? HomeFlag { get; set; }

        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }
        public int SortOrder { set; get; }
        public Status Status { set; get; }

        public virtual ICollection<ProductViewModel> Products { get; set; }
    }
}
