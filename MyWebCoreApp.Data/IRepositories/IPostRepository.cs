using MyWebCoreApp.Data.Entities;
using MyWebCoreApp.Infrastructure.Interfaces;

namespace MyWebCoreApp.Data.IRepositories
{
    public interface IPostRepository : IRepository<Post, int>
    {
    }
}