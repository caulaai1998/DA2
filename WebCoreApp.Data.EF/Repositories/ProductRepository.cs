using System;
using System.Collections.Generic;
using System.Text;
using WebCoreApp.Data.Entities;
using WebCoreApp.Data.IRepositories;

namespace WebCoreApp.Data.EF.Repositories
{
    public class ProductRepository: EFRepository<Product,int>,IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {

        }
    }
}
