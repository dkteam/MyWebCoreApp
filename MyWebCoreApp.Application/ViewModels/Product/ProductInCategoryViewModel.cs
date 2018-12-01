using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebCoreApp.Application.ViewModels.Product
{
    public class ProductInCategoryViewModel
    {
        public int ProductId { get; set; }

        public string CategoryId { set; get; }

        public ProductViewModel Product { get; set; }

        public ProductCategoryViewModel ProductCategory { get; set; }
    }
}
