using MyWebCoreApp.Data.Entities;
using MyWebCoreApp.Data.IRepositories;

namespace MyWebCoreApp.Data.EF.Repositories
{
    public class PostTagRepository : EFRepository<PostTag, int>, IPostTagRepository
    {
        public PostTagRepository(AppDbContext context) : base(context)
        {
        }
    }
}