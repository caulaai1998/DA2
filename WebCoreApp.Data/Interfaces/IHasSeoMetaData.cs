using System;
using System.Collections.Generic;
using System.Text;

namespace WebCoreApp.Data.Interfaces
{
    public interface IHasSeoMetaData
    {
        string SeoPageTitle { set; get; }
        string SeoAlias { set; get; }
        string SeoKeywords { set; get; }
        string SeoDescription { get; set; }
    }
}
