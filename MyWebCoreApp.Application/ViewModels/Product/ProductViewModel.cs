using MyWebCoreApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebCoreApp.Application.ViewModels.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public bool? HomeFlag { get; set; }

        public bool? HotFlag { get; set; }

        public string ThumbnailImage { get; set; }

        public string ImageList { get; set; }

        public decimal? Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        public string Tags { get; set; }

        public int? ViewCount { get; set; }

        public string Domain { get; set; }

        public int TypeId { get; set; }

        public Status Status { get; set; }

        public string SeoPageTitle { get; set; }

        public string SeoAlias { get; set; }

        public string SeoKeywords { get; set; }

        public string SeoDescription { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public ProductTypeViewModel ProductType { get; set; }

        public ICollection<ProductInCategoryViewModel> ProductInCategories { set; get; }
    }
}
