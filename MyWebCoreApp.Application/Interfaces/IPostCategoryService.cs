using MyWebCoreApp.Application.ViewModels.Post;
using System;
using System.Collections.Generic;

namespace MyWebCoreApp.Application.Interfaces
{
    public interface IPostCategoryService : IDisposable
    {
        PostCategoryViewModel Add(PostCategoryViewModel postCategoryVm);

        List<PostCategoryViewModel> GetAll();

        void UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items);

        void ReOrder(int sourceId, int targetId);

        PostCategoryViewModel GetById(int id);

        void Update(PostCategoryViewModel postCategoryVm);

        void Delete(int id);

        void Save();
    }
}