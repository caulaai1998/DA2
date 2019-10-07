using System;
using System.Collections.Generic;
using System.Text;

namespace WebCoreApp.Data.Interfaces
{
    public interface IHasOwner<T>
    {
        T OwnerId { set; get; }
    }
}
