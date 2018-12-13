using MyWebCoreApp.Application.ViewModels.Post;
using System;
using System.Collections.Generic;

namespace MyWebCoreApp.Application.Interfaces
{
    public interface IPostCategoryService : IDisposable
    {
        List<PostCategoryViewModel> GetAll();
    }
}