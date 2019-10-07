using System;
using System.Collections.Generic;
using System.Text;
using WebCoreApp.Data.Entities;
using WebCoreApp.Data.IRepositories;

namespace WebCoreApp.Data.EF.Repositories
{
    public class ColorRepository : EFRepository<Color, int>, IColorRepository
    {
        public ColorRepository(AppDbContext context) : base(context)
        {
        }
    }
}
