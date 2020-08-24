using BitzenVehicleManagementAPI.DTOs;
using BitzenVehicleManagementAPI.Models;
using BitzenVehicleManagementAPI.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BitzenVehicleManagementAPI.Data.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly BitzenApplicationContext _context;

        public ReportRepository(BitzenApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<ReportDto> AvgMonthMileageByLiter(Expression<Func<ReportDto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public IEnumerable<ReportDto> LitersByMonth(Expression<Func<ReportDto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReportDto> MileageByMonth(Expression<Func<ReportDto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReportDto> ValueByMonth(Expression<Func<ReportDto, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
