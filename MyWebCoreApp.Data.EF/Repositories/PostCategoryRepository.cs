using MyWebCoreApp.Data.Entities;
using MyWebCoreApp.Data.IRepositories;

namespace MyWebCoreApp.Data.EF.Repositories
{
    public class PostCategoryRepository : EFRepository<PostCategory, int>, IPostCategoryRepository
    {
        public PostCategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}