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
    [Table("ProductCategories")]
    public class ProductCategory : DomainEntity<int>, IDateTracking,  IHasSeoMetaData, IHasSoftDelete, ISortable, ISwitchable
    {
        public ProductCategory()
        {
            ProductInCategories = new List<ProductInCategory>();
        }

        public ProductCategory(string name, string description, int? parentId, int? homeOrder, string detail, bool? homeFlag, string thumbnailImage, bool isDelete, string seoPageTitle,
            string seoAlias, string seoKeywords, string seoDescription, Status status, int? sortOrder)
        {
            Name = name;
            Description = description;
            Detail = detail;
            ParentId = parentId;
            HomeOrder = homeOrder;
            HomeFlag = homeFlag;
            ThumbnailImage = thumbnailImage;
            IsDeleted = isDelete;
            SeoPageTitle = seoPageTitle;
            SeoAlias = seoAlias;
            SeoKeywords = seoKeywords;
            SeoDescription = seoDescription;
            Status = status;
            SortOrder = sortOrder;
        }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public string Detail { get; set; }

        public int? ParentId { get; set; }

        public int? HomeOrder { get; set; }

        public bool? HomeFlag { get; set; }

        [StringLength(255)]
        [Required]
        public string ThumbnailImage { get; set; }

        public bool IsDeleted { get; set; }

        [StringLength(255)]
        [Required]
        public string SeoPageTitle { get; set; }

        [StringLength(255)]
        [Column(TypeName = "varchar(255)")]
        [Required]
        public string SeoAlias { get; set; }

        [StringLength(255)]
        public string SeoKeywords { get; set; }

        [StringLength(255)]
        public string SeoDescription { get; set; }
        
        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public Status Status { get; set; }

        public int? SortOrder { get; set; }

        public virtual ICollection<ProductInCategory> ProductInCategories { set; get; }
    }
}
