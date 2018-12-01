using MyWebCoreApp.Data.Enums;
using MyWebCoreApp.Data.Interfaces;
using MyWebCoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyWebCoreApp.Data.Entities
{
    [Table("Slides")]
    public class Slide : DomainEntity<int>, IDateTracking, ISortable, ISwitchable
    {
        [StringLength(250)]
        [Required]
        public string Name { set; get; }

        [StringLength(250)]
        public string Description { set; get; }

        [StringLength(250)]
        [Required]
        public string Image { set; get; }

        [StringLength(250)]
        public string Url { set; get; }

        public int? DisplayOrder { set; get; }
        
        public string Content { set; get; }

        public int GroupId { get; set; }

        public Status Status { get; set; }

        public int? SortOrder { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        [ForeignKey("GroupId")]
        public virtual GroupSlide GroupSlide { get; set; }
    }
}
