using System;
using System.Collections.Generic;
using System.Text;
using WebCoreApp.Application.ViewModels.Common;

namespace WebCoreApp.Application.Interfaces
{
    public interface ICommonService
    {
        FooterViewModel GetFooter();
        List<SlideViewModel> GetSlides(string groupAlias);
        SystemConfigViewModel GetSystemConfig(string code);
    }

}
