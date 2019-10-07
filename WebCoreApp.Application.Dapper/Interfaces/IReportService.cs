using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebCoreApp.Application.Dapper.ViewModels;

namespace WebCoreApp.Application.Dapper.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<RevenueReportViewModel>> GetReportAsync(string fromDate, string toDate);
    }
}
