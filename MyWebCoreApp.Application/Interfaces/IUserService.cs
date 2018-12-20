using MyWebCoreApp.Application.ViewModels.System;
using MyWebCoreApp.Utilities.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyWebCoreApp.Application.Interfaces
{
    public interface IUserService
    {
        Task<bool> AddAsync(AppUserViewModel userVm);

        Task DeleteAsync(string id);

        Task<List<AppUserViewModel>> GetAllAsync();

        PageResult<AppUserViewModel> GetAllPagingAsync(string keyword, int page, int pageSize);

        Task<AppUserViewModel> GetById(string id);

        Task UpdateAsync(AppUserViewModel userVm);
    }
}