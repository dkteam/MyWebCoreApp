using AutoMapper;
using MyWebCoreApp.Application.ViewModels.Post;
using MyWebCoreApp.Application.ViewModels.Product;
using MyWebCoreApp.Data.Entities;

namespace MyWebCoreApp.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductCategoryViewModel, ProductCategory>()
                .ConstructUsing(c => new ProductCategory(c.Name, c.Description, c.ParentId, c.HomeOrder, c.Detail, c.HomeFlag, c.ThumbnailImage, c.IsDeleted, c.SeoPageTitle, c.SeoAlias, c.SeoKeywords, c.SeoDescription, c.Status, c.SortOrder));
            CreateMap<ProductViewModel, Product>()
                .ConstructUsing(c => new Product(c.Name, c.Description, c.Content, c.HomeFlag, c.HotFlag, c.ThumbnailImage, c.ImageList, c.Price, c.PromotionPrice, c.Tags, c.ViewCount, c.Domain, c.TypeId, c.Status, c.SeoPageTitle, c.SeoAlias, c.SeoKeywords, c.SeoDescription));
            CreateMap<PostViewModel, Post>()
                .ConstructUsing(c => new Post(c.Name, c.Description, c.Content, c.ThumbnailImage, c.Image, c.HomeFlag, c.HotFlag, c.Tags, c.ViewCount, c.CategoryId, c.Status, c.IsDeleted, c.SeoPageTitle, c.SeoAlias, c.SeoKeywords, c.SeoDescription));
        }
    }
}