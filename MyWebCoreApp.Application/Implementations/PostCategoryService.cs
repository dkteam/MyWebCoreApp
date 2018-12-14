using AutoMapper;
using AutoMapper.QueryableExtensions;
using MyWebCoreApp.Application.Interfaces;
using MyWebCoreApp.Application.ViewModels.Post;
using MyWebCoreApp.Data.Entities;
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

        public PostCategoryViewModel Add(PostCategoryViewModel postCategoryVm)
        {
            var postCategory = Mapper.Map<PostCategoryViewModel, PostCategory>(postCategoryVm);
            _postCategoryRepository.Add(postCategory);
            return postCategoryVm;
        }

        public void Delete(int id)
        {
            _postCategoryRepository.Remove(id);
        }

        public List<PostCategoryViewModel> GetAll()
        {
            return _postCategoryRepository.FindAll().OrderBy(x => x.ParentId).ProjectTo<PostCategoryViewModel>().ToList();
        }

        public PostCategoryViewModel GetById(int id)
        {
            return Mapper.Map<PostCategory, PostCategoryViewModel>(_postCategoryRepository.FindById(id));
        }

        public void ReOrder(int sourceId, int targetId)
        {
            var source = _postCategoryRepository.FindById(sourceId);
            var target = _postCategoryRepository.FindById(targetId);

            int tempOrder = source.SortOrder.Value;
            source.SortOrder = target.SortOrder;
            target.SortOrder = tempOrder;

            _postCategoryRepository.Update(source);
            _postCategoryRepository.Update(target);
        }

        public void UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items)
        {
            var sourceCategory = _postCategoryRepository.FindById(sourceId);
            sourceCategory.ParentId = targetId;
            _postCategoryRepository.Update(sourceCategory);

            //get all sibling
            var sibling = _postCategoryRepository.FindAll(x => items.ContainsKey(x.Id));
            foreach(var child in sibling)
            {
                child.SortOrder = items[child.Id];
                _postCategoryRepository.Update(child);
            }
        }

        public void Update(PostCategoryViewModel postCategoryVm)
        {
            var productCategory = Mapper.Map<PostCategoryViewModel, PostCategory>(postCategoryVm);
            _postCategoryRepository.Update(productCategory);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}