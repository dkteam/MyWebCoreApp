using MyWebCoreApp.Application.ViewModels.Post;
using MyWebCoreApp.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebCoreApp.Application.Interfaces
{
    public interface IPostService : IDisposable
    {
        List<PostViewModel> GetAll();

        PageResult<PostViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize);

        PostViewModel GetById(int id);

        PostViewModel Add(PostViewModel post);

        void Update(PostViewModel post);

        void Delete(int id);

        void Save();
    }
}
