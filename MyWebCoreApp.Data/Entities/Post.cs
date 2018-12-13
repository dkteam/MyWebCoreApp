using MyWebCoreApp.Data.Enums;
using MyWebCoreApp.Data.Interfaces;
using MyWebCoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebCoreApp.Data.Entities
{
    [Table("Posts")]
    public class Post : DomainEntity<int>, IDateTracking, IHasSeoMetaData, IHasSoftDelete, ISwitchable
    {
        public Post()
        {
            PostTags = new List<PostTag>();
        }

        public Post(int id, string name, string description, string content, string thumbnailImage, string image, bool? homeFlag, bool? hotFlag, string tags, int? viewCount, int categoryId,
          Status status, bool isDeleted, string seoPageTitle, string seoAlias, string seoKeywords, string seoDescription)
        {
            Id = id;
            Name = name;
            Description = description;
            Content = content;
            ThumbnailImage = thumbnailImage;
            Image = image;
            HomeFlag = homeFlag;
            HotFlag = hotFlag;
            Tags = tags;
            ViewCount = viewCount;
            CategoryId = categoryId;
            Status = status;
            IsDeleted = isDeleted;
            SeoPageTitle = seoPageTitle;
            SeoAlias = seoAlias;
            SeoDescription = seoDescription;
            SeoKeywords = seoKeywords;
            PostTags = new List<PostTag>();
        }

        public Post(string name, string description, string content, string thumbnailImage, string image, bool? homeFlag, bool? hotFlag, string tags, int? viewCount, int categoryId, 
            Status status, bool isDeleted, string seoPageTitle, string seoAlias, string seoKeywords, string seoDescription)
        {
            Name = name;
            Description = description;
            Content = content;
            ThumbnailImage = thumbnailImage;
            Image = image;
            HomeFlag = homeFlag;
            HotFlag = hotFlag;
            Tags = tags;
            ViewCount = viewCount;
            CategoryId = categoryId;
            Status = status;
            IsDeleted = isDeleted;
            SeoPageTitle = seoPageTitle;
            SeoAlias = seoAlias;
            SeoDescription = seoDescription;
            SeoKeywords = seoKeywords;
            PostTags = new List<PostTag>();
        }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public string Content { get; set; }

        [StringLength(255)]
        public string ThumbnailImage { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        public bool? HomeFlag { get; set; }

        public bool? HotFlag { get; set; }

        [StringLength(500)]
        public string Tags { get; set; }

        public int? ViewCount { get; set; }

        public int CategoryId { get; set; }

        public Status Status { get; set; }

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

        [ForeignKey("CategoryId")]
        public virtual PostCategory PostCategory { get; set; }

        public virtual ICollection<PostTag> PostTags { get; set; }
    }
}