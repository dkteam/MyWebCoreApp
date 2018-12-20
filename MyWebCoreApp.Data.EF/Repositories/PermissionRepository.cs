using MyWebCoreApp.Data.Entities;
using MyWebCoreApp.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebCoreApp.Data.EF.Repositories
{
    public class PermissionRepository : EFRepository<Permission, int>, IPermissionRepository
    {
        public PermissionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
