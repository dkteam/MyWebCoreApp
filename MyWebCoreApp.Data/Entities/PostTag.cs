using MyWebCoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyWebCoreApp.Data.Entities
{
    [Table("PostTags")]
    public class PostTag : DomainEntity<int>
    {        
        public int PostId { get; set; }

        [StringLength(100)]
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string TagId { get; set; }

        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }

        [ForeignKey("TagId")]
        public virtual Tag Tag { get; set; }
    }
}
