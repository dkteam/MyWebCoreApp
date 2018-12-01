using MyWebCoreApp.Infrastructure.SharedKernel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebCoreApp.Data.Entities
{
    [Table("ProductTypes")]
    public class ProductType : DomainEntity<int>
    {
        public ProductType()
        {
            Products = new List<Product>();
        }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { set; get; }
    }
}