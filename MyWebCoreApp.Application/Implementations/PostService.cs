using AutoMapper;
using AutoMapper.QueryableExtensions;
using MyWebCoreApp.Application.Interfaces;
using MyWebCoreApp.Application.ViewModels.Post;
using MyWebCoreApp.Data.Entities;
using MyWebCoreApp.Data.Enums;
using MyWebCoreApp.Data.IRepositories;
using MyWebCoreApp.Infrastructure.Interfaces;
using MyWebCoreApp.Utilities.Constants;
using MyWebCoreApp.Utilities.Dtos;
using MyWebCoreApp.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyWebCoreApp.Application.Implementations
{
    public class PostService : IPostService
    {
        private IPostRepository _postRepository;
        private ITagRepository _tagRepository;
        private IPostTagRepository _postTagRepository;
        private IUnitOfWork _unitOfWork;

        public PostService(IPostRepository postRepository, IPostTagRepository postTagRepository, ITagRepository tagRepository, IUnitOfWork unitOfWork)
        {
            this._postRepository = postRepository;
            this._postTagRepository = postTagRepository;
            this._tagRepository = tagRepository;
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

        public PostViewModel GetById(int id)
        {
            return Mapper.Map<Post, PostViewModel>(_postRepository.FindById(id));
        }

        public PostViewModel Add(PostViewModel postVm)
        {
            if (!string.IsNullOrEmpty(postVm.Tags))
            {
                List<PostTag> postTags = new List<PostTag>();
                string[] tags = postVm.Tags.Split(',');
                foreach (string t in tags)
                {
                    var tagId = TextHelper.ToUnsignString(t);
                    if (!_tagRepository.FindAll(x => x.Id == tagId).Any())
                    {
                        Tag tag = new Tag
                        {
                            Id = tagId,
                            Name = t,
                            Type = CommonConstants.PostTag
                        };
                        _tagRepository.Add(tag);
                    }

                    PostTag postTag = new PostTag
                    {
                        TagId = tagId
                    };
                    postTags.Add(postTag);
                }
                var post = Mapper.Map<PostViewModel, Post>(postVm);
                foreach (var postTag in postTags)
                {
                    post.PostTags.Add(postTag);
                }
                _postRepository.Add(post);
                return postVm;
            }
            else
            {
                _postRepository.Add(Mapper.Map<PostViewModel, Post>(postVm));
                return postVm;
            }

        }

        public void Delete(int id)
        {
            _postRepository.Remove(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(PostViewModel postVm)
        {
            List<PostTag> postTags = new List<PostTag>();

            if (!string.IsNullOrEmpty(postVm.Tags))
            {
                string[] tags = postVm.Tags.Split(',');
                foreach (string t in tags)
                {
                    var tagId = TextHelper.ToUnsignString(t);
                    if (!_tagRepository.FindAll(x => x.Id == tagId).Any())
                    {
                        Tag tag = new Tag();
                        tag.Id = tagId;
                        tag.Name = t;
                        tag.Type = CommonConstants.PostTag;
                        _tagRepository.Add(tag);
                    }
                    _postTagRepository.RemoveMultiple(_postTagRepository.FindAll(x => x.Id == postVm.Id).ToList());
                    PostTag postTag = new PostTag
                    {
                        TagId = tagId
                    };
                    postTags.Add(postTag);
                    //_productTagRepository.Add(productTag);
                }
            }

            var post = Mapper.Map<PostViewModel, Post>(postVm);
            foreach (var productTag in postTags)
            {
                post.PostTags.Add(productTag);
            }
            _postRepository.Update(post);
        }
    }
}
