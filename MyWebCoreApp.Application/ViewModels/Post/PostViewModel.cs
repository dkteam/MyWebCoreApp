using MyWebCoreApp.Data.Enums;
using System;
using System.Collections.Generic;

namespace MyWebCoreApp.Application.ViewModels.Post
{
    public class PostViewModel
    {
        public int Id { set; get; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public string ThumbnailImage { get; set; }

        public string Image { get; set; }

        public bool? HomeFlag { get; set; }

        public bool? HotFlag { get; set; }

        public string Tags { get; set; }

        public int? ViewCount { get; set; }

        public int CategoryId { get; set; }

        public Status Status { get; set; }

        public bool IsDeleted { get; set; }

        public string SeoPageTitle { get; set; }

        public string SeoAlias { get; set; }

        public string SeoKeywords { get; set; }

        public string SeoDescription { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public PostCategoryViewModel PostCategory { get; set; }

        public ICollection<PostTagViewModel> PostTags { get; set; }
    }
}