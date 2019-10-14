using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebCoreApp.Data.Enums;
using WebCoreApp.Infrastructure.SharedKernel;

namespace WebCoreApp.Data.Entities
{
    [Table("Authors")]
    public class Author : DomainEntity<int>
    {
        public Author()
        {

        }

        public Author(string authorName, string description, int? parentId, int? homeOrder,
             bool? homeFlag, int sortOrder, Status status
            )
        {
            AuthorName = authorName;
            Description = description;
            ParentId = parentId;
            HomeOrder = homeOrder;
            HomeFlag = homeFlag;
            SortOrder = sortOrder;
            Status = status;

        }

        public string AuthorName { get; set; }

        public string Description { get; set; }

        public int? ParentId { get; set; }

        public int? HomeOrder { get; set; }


        public bool? HomeFlag { get; set; }

        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }
        public int SortOrder { set; get; }
        public Status Status { set; get; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
