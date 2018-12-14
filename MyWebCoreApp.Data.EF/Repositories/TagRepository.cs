using MyWebCoreApp.Data.Entities;
using MyWebCoreApp.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebCoreApp.Data.EF.Repositories
{
    public class TagRepository : EFRepository<Tag, string>, ITagRepository
    {
        public TagRepository(AppDbContext context) : base(context)
        {
        }
    }
}
