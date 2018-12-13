using AutoMapper.QueryableExtensions;
using MyWebCoreApp.Application.Interfaces;
using MyWebCoreApp.Application.ViewModels.Post;
using MyWebCoreApp.Data.IRepositories;
using MyWebCoreApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWebCoreApp.Application.Implementations
{
    public class PostCategoryService : IPostCategoryService
    {
        private IPostCategoryRepository _postCategoryRepository;
        private IUnitOfWork _unitOfWork;

        public PostCategoryService(IPostCategoryRepository postCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._postCategoryRepository = postCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<PostCategoryViewModel> GetAll()
        {
            return _postCategoryRepository.FindAll().OrderBy(x => x.ParentId).ProjectTo<PostCategoryViewModel>().ToList();
        }
    }
}