using AutoMapper;
using MyWebCoreApp.Application.ViewModels.Post;
using MyWebCoreApp.Application.ViewModels.Product;
using MyWebCoreApp.Application.ViewModels.System;
using MyWebCoreApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebCoreApp.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ProductCategory, ProductCategoryViewModel>();
            CreateMap<Function, FunctionViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<Post, PostViewModel>();
            CreateMap<PostCategory, PostCategoryViewModel>();
            CreateMap<AppUser, AppUserViewModel>();
            CreateMap<AppRole, AppRoleViewModel>();
        }
    }
}
