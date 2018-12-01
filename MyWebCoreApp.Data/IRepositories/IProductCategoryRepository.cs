using MyWebCoreApp.Data.Entities;
using MyWebCoreApp.Infrastructure.Interfaces;
using System.Collections.Generic;

namespace MyWebCoreApp.Data.IRepositories
{
    public interface IProductCategoryRepository : IRepository<ProductCategory, int>
    {
        List<ProductCategory> GetByAlias(string alias);
    }
}