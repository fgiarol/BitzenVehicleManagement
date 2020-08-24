using BitzenVehicleManagementAPI.Extensions;
using BitzenVehicleManagementAPI.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitzenVehicleManagementAPI.Services
{
    public class ReportService
    {
        private readonly IReportRepository _repo;
        private readonly IUser _user;

        public ReportService(IReportRepository repo, IUser user)
        {
            _repo = repo;
            _user = user;
        }


    }
}
