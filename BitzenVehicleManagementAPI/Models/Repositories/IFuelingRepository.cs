using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BitzenVehicleManagementAPI.Models.Repositories
{
    public interface IFuelingRepository : IDisposable
    {
        Fueling Create(Fueling fueling);
        Fueling Find(long fuelingId);
        IEnumerable<Fueling> FindAll(Expression<Func<Fueling, bool>> predicate);
        void Delete(Fueling fueling);
        Fueling Update(Fueling fueling);
    }
}
