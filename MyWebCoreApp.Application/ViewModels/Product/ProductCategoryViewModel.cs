﻿using MyWebCoreApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebCoreApp.Application.ViewModels.Product
{
    public class ProductCategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Detail { get; set; }

        public int? ParentId { get; set; }

        public int? HomeOrder { get; set; }

        public bool? HomeFlag { get; set; }

        public string ThumbnailImage { get; set; }

        public bool IsDeleted { get; set; }

        public string SeoPageTitle { get; set; }

        public string SeoAlias { get; set; }

        public string SeoKeywords { get; set; }

        public string SeoDescription { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public Status Status { get; set; }

        public int? SortOrder { get; set; }

        public ICollection<ProductInCategoryViewModel> ProductInCategories { set; get; }
    }
}
