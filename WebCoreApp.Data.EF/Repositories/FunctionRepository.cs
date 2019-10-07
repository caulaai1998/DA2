using System;
using System.Collections.Generic;
using System.Text;
using WebCoreApp.Data.Entities;
using WebCoreApp.Data.IRepositories;

namespace WebCoreApp.Data.EF.Repositories
{
    public class FunctionRepository : EFRepository<Function,string>,IFunctionRepository
    {
        public FunctionRepository(AppDbContext context) : base(context)
        {

        }
    }
}
