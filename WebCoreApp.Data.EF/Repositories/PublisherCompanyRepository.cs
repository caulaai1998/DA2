using System;
using System.Collections.Generic;
using System.Text;
using WebCoreApp.Data.Entities;
using WebCoreApp.Data.IRepositories;

namespace WebCoreApp.Data.EF.Repositories
{
    public class PublisherCompanyRepository : EFRepository<Publisher, int>, IPublisherCompanyRepository
    {
        AppDbContext _context;
        public PublisherCompanyRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
