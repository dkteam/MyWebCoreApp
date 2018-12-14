using MyWebCoreApp.Data.Entities;
using MyWebCoreApp.Data.IRepositories;

namespace MyWebCoreApp.Data.EF.Repositories
{
    public class ProductTagRepository : EFRepository<ProductTag, int>, IProductTagRepository
    {
        public ProductTagRepository(AppDbContext context) : base(context)
        {
        }
    }
}