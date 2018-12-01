using MyWebCoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyWebCoreApp.Data.Entities
{
    [Table("ProductInCategories")]
    public class ProductInCategory : DomainEntity<int>
    {
        public int ProductId { get; set; }

        public int CategoryId { set; get; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [ForeignKey("CategoryId")]
        public virtual ProductCategory ProductCategory { get; set; }
    }
}
