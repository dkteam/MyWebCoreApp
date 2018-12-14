﻿using MyWebCoreApp.Data.Entities;
using MyWebCoreApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebCoreApp.Data.IRepositories
{
    public interface IPostTagRepository : IRepository<PostTag, int>
    {
    }
}
