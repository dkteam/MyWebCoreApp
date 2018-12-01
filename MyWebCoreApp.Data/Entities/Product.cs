using MyWebCoreApp.Data.Enums;
using MyWebCoreApp.Data.Interfaces;
using MyWebCoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebCoreApp.Data.Entities
{
    [Table("Products")]
    public class Product : DomainEntity<int>, IDateTracking, IHasSeoMetaData, ISwitchable
    {
        public Product()
        {
            ProductInCategories = new List<ProductInCategory>();
            ProductTags = new List<ProductTag>();
        }

        public Product(string name, string description, string content, bool? homeFlag, bool? hotFlag, string thumbnailImage, string imageList, decimal? price, decimal? promotionPrice,
            string tags, int? viewCount, string domain, int typeId, Status status, string seoPageTitle, string seoAlias, string seoKeywords, string seoDescription)
        {
            Name = name;
            Description = description;
            Content = content;
            HomeFlag = homeFlag;
            HotFlag = hotFlag;
            ThumbnailImage = thumbnailImage;
            ImageList = imageList;
            Price = price;
            PromotionPrice = promotionPrice;
            Tags = tags;
            ViewCount = viewCount;
            Domain = domain;
            TypeId = typeId;
            Status = status;
            SeoPageTitle = seoPageTitle;
            SeoAlias = seoAlias;
            SeoKeywords = seoKeywords;
            SeoDescription = seoDescription;
            ProductTags = new List<ProductTag>();
        }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public string Content { get; set; }

        public bool? HomeFlag { get; set; }

        public bool? HotFlag { get; set; }

        [StringLength(255)]
        [Required]
        public string ThumbnailImage { get; set; }

        [StringLength(1000)]
        public string ImageList { get; set; }

        public decimal? Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        [StringLength(500)]
        public string Tags { get; set; }

        public int? ViewCount { get; set; }

        public string Domain { get; set; }

        [Required]
        public int TypeId { get; set; }

        public Status Status { get; set; }

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

        [ForeignKey("TypeId")]
        public virtual ProductType ProductType { get; set; }

        public virtual ICollection<ProductInCategory> ProductInCategories { set; get; }

        public virtual ICollection<ProductImage> ProductImages { get; set; }

        public virtual ICollection<ProductTag> ProductTags { set; get; }
    }
}