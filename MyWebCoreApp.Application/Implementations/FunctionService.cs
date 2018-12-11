using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MyWebCoreApp.Application.Interfaces;
using MyWebCoreApp.Application.ViewModels.System;
using MyWebCoreApp.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyWebCoreApp.Application.Implementations
{
    public class FunctionService : IFunctionService
    {
        IFunctionRepository _functionRepository;

        public FunctionService(IFunctionRepository functionRepository)
        {
            this._functionRepository = functionRepository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Task<List<FunctionViewModel>> GetAll()
        {
            return _functionRepository.FindAll().ProjectTo<FunctionViewModel>().ToListAsync();
        }

        public List<FunctionViewModel> GetAllByPermission(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
