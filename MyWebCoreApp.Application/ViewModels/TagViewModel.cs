using MyWebCoreApp.Application.ViewModels.Post;
using MyWebCoreApp.Application.ViewModels.Product;
using System.Collections.Generic;

namespace MyWebCoreApp.Application.ViewModels
{
    public class TagViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public ICollection<PostTagViewModel> PostTags { get; set; }

        public ICollection<ProductTagViewModel> ProductTags { get; set; }
    }
}