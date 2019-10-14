using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebCoreApp.Data.Enums;
using WebCoreApp.Infrastructure.SharedKernel;

namespace WebCoreApp.Data.Entities
{
    [Table("Publishers")]
    public class Publisher : DomainEntity<int>
    {
        public Publisher()
        {

        }

        public Publisher(string publisherName, string description, int? parentId, int? homeOrder,
             bool? homeFlag, int sortOrder, Status status
            )
        {
            PublisherName = publisherName;
            Description = description;
            ParentId = parentId;
            HomeOrder = homeOrder;
            HomeFlag = homeFlag;
            SortOrder = sortOrder;
            Status = status;

        }

        public string PublisherName { get; set; }

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
