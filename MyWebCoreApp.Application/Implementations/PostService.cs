using AutoMapper.QueryableExtensions;
using MyWebCoreApp.Application.Interfaces;
using MyWebCoreApp.Application.ViewModels.Post;
using MyWebCoreApp.Data.Enums;
using MyWebCoreApp.Data.IRepositories;
using MyWebCoreApp.Infrastructure.Interfaces;
using MyWebCoreApp.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyWebCoreApp.Application.Implementations
{
    public class PostService : IPostService
    {
        private IPostRepository _postRepository;
        private IUnitOfWork _unitOfWork;

        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            this._postRepository = postRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<PostViewModel> GetAll()
        {
            return _postRepository.FindAll(x=>x.PostCategory).ProjectTo<PostViewModel>().ToList();
        }

        public PageResult<PostViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize)
        {
            var query = _postRepository.FindAll(x => x.Status == Status.Active);
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Name.Contains(keyword));
            if (categoryId.HasValue)
                query = query.Where(x => x.CategoryId == categoryId.Value);

            int totalRow = query.Count();

            query = query.OrderByDescending(x => x.CreatedDate)
                .Skip((page - 1) * pageSize).Take(pageSize);

            var data = query.ProjectTo<PostViewModel>().ToList();

            var paginationSet = new PageResult<PostViewModel>()
            {
                Results = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize, 
            };

            return paginationSet;
        }
    }
}
