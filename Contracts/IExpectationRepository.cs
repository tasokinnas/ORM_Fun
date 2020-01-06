using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface IExpectationRepository : IRepositoryBase<Expectation>
    {
        IEnumerable<Expectation> GetAllExpectations();
        Expectation GetExpectationById(Guid Cohort_Id, Guid Facet_Id);
    }
}
