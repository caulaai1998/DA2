using System;
using System.Collections.Generic;
using System.Text;

namespace WebCoreApp.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
