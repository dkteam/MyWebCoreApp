using MyWebCoreApp.Data.Entities;
using MyWebCoreApp.Data.IRepositories;

namespace MyWebCoreApp.Data.EF.Repositories
{
    public class PostRepository : EFRepository<Post, int>, IPostRepository
    {
        public PostRepository(AppDbContext context) : base(context)
        {
        }
    }
}