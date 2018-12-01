using MyWebCoreApp.Infrastructure.SharedKernel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebCoreApp.Data.Entities
{
    [Table("Tags")]
    public class Tag : DomainEntity<string>
    {
        public Tag()
        {
            PostTags = new List<PostTag>();
            ProductTags = new List<ProductTag>();
        }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(50)]
        [Required]
        public string Type { get; set; }

        public virtual ICollection<PostTag> PostTags { get; set; }
        public virtual ICollection<ProductTag> ProductTags { get; set; }
    }
}