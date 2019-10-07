using System;
using System.Collections.Generic;
using System.Text;
using WebCoreApp.Data.Entities;
using WebCoreApp.Data.IRepositories;

namespace WebCoreApp.Data.EF.Repositories
{
    public class SystemConfigRepository : EFRepository<SystemConfig, string>, ISystemConfigRepository
    {
        public SystemConfigRepository(AppDbContext dbFactory) : base(dbFactory)
        {
        }
    }
}
