using System;
using System.Collections.Generic;
using System.Text;
using WebCoreApp.Data.Entities;
using WebCoreApp.Data.IRepositories;

namespace WebCoreApp.Data.EF.Repositories
{
    public class PageRepository : EFRepository<Page, int>, IPageRepository
    {
        public PageRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
