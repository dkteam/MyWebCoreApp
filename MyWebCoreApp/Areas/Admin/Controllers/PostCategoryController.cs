using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MyWebCoreApp.Application.Interfaces;
using MyWebCoreApp.Application.ViewModels.Post;
using MyWebCoreApp.Utilities.Helpers;

namespace MyWebCoreApp.Areas.Admin.Controllers
{
    public class PostCategoryController : BaseController
    {
        IPostCategoryService _postCategoryService;
        
        public PostCategoryController(IPostCategoryService postCategoryService)
        {
            this._postCategoryService = postCategoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region API 
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var model = _postCategoryService.GetById(id);
            return new ObjectResult(model);
        }

        [HttpPost]
        public IActionResult SaveEntity(PostCategoryViewModel postCategoryVm)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            else
            {
                postCategoryVm.SeoAlias = TextHelper.ToUnsignString(postCategoryVm.Name);
                if (postCategoryVm.Id == 0)
                {
                    _postCategoryService.Add(postCategoryVm);
                }
                else
                {
                    _postCategoryService.Update(postCategoryVm);
                }
                _postCategoryService.Save();
                return new OkObjectResult(postCategoryVm);

            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new BadRequestResult();
            }
            else
            {
                _postCategoryService.Delete(id);
                _postCategoryService.Save();
                return new OkObjectResult(id);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var model = _postCategoryService.GetAll();
            return new OkObjectResult(model);
        }

        [HttpPost]
        public IActionResult UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            else
            {
                if (sourceId == targetId)
                {
                    return new BadRequestResult();
                }
                else
                {
                    _postCategoryService.UpdateParentId(sourceId, targetId, items);
                    _postCategoryService.Save();
                    return new OkResult();
                }
            }
        }

        [HttpPost]
        public IActionResult ReOrder(int sourceId, int targetId)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            else
            {
                if (sourceId == targetId)
                {
                    return new BadRequestResult();
                }
                else
                {
                    _postCategoryService.ReOrder(sourceId, targetId);
                    _postCategoryService.Save();
                    return new OkResult();
                }
            }
        }
        #endregion
    }
}