using BitzenVehicleManagementAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BitzenVehicleManagementAPI.Models.Repositories
{
    public interface IReportRepository : IDisposable
    {
        IEnumerable<ReportDto> LitersByMonth(Expression<Func<Fueling, bool>> predicate);
        IEnumerable<ReportDto> ValueByMonth(Expression<Func<Fueling, bool>> predicate);
        IEnumerable<ReportDto> MileageByMonth(Expression<Func<ReportDto, bool>> predicate);
        IEnumerable<ReportDto> AvgMonthMileageByLiter(Expression<Func<ReportDto, bool>> predicate);
    }
}
