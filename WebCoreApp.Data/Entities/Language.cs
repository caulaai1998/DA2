using WebCoreApp.Data.Interfaces;
using WebCoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebCoreApp.Data.Enums;

namespace WebCoreApp.Data.Entities
{
    [Table("Languages")]
    public class Language : DomainEntity<string>, ISwitchable
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public bool IsDefault { get; set; }

        public string Resources { get; set; }

        public Status Status { get; set; }
    }
}
