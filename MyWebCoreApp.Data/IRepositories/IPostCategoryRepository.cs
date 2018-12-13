using MyWebCoreApp.Data.Entities;
using MyWebCoreApp.Infrastructure.Interfaces;

namespace MyWebCoreApp.Data.IRepositories
{
    public interface IPostCategoryRepository : IRepository<PostCategory, int>
    {
    }
}