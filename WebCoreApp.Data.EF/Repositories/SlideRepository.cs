using System;
using System.Collections.Generic;
using System.Text;
using WebCoreApp.Data.Entities;
using WebCoreApp.Data.IRepositories;

namespace WebCoreApp.Data.EF.Repositories
{
    public class SlideRepository : EFRepository<Slide, int>, ISlideRepository
    {
        public SlideRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
