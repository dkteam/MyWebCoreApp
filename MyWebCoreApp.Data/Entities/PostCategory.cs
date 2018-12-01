using MyWebCoreApp.Data.Enums;
using MyWebCoreApp.Data.Interfaces;
using MyWebCoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebCoreApp.Data.Entities
{
    [Table("PostCategories")]
    public class PostCategory : DomainEntity<int>, IDateTracking, IHasSeoMetaData, ISwitchable, IHasSoftDelete, ISortable
    {
        public PostCategory()
        {
            Posts = new List<Post>();
        }

        public PostCategory(string name, string description, int? parentId, string thumbnailImage, bool? homeFlag, bool isDeleted, Status status, string seoPageTitle, string seoAlias, string seoKeywords, string seoDescription, int? sortOrder)
        {
            Name = name;
            Description = description;
            ParentId = parentId;
            ThumbnailImage = thumbnailImage;
            HomeFlag = homeFlag;
            IsDeleted = isDeleted;
            Status = status;
            SeoPageTitle = seoPageTitle;
            SeoAlias = seoAlias;
            SeoKeywords = seoKeywords;
            SeoDescription = SeoDescription;
            SortOrder = sortOrder;

        }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public int? ParentId { get; set; }

        [StringLength(255)]
        public string ThumbnailImage { get; set; }

        public bool? HomeFlag { get; set; }

        public bool IsDeleted { get; set; }

        public Status Status { get; set; }

        [StringLength(255)]
        [Required]
        public string SeoPageTitle { get; set; }

        [StringLength(255)]
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string SeoAlias { get; set; }

        [StringLength(255)]
        public string SeoKeywords { get; set; }

        [StringLength(255)]
        public string SeoDescription { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int? SortOrder { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}