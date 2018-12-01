using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebCoreApp.Application.ViewModels.Product
{
    public class ProductTypeViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<ProductViewModel> Products { set; get; }
    }
}
