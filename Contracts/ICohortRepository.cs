using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface ICohortRepository : IRepositoryBase<Cohort>
    {
        IEnumerable<Cohort> GetAllCohorts();
        Cohort GetCohortById(Guid Id);
    }
}
