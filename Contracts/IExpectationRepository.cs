using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface IExpectationRepository : IRepositoryBase<Expectation>
    {
        IEnumerable<Expectation> GetAllExpectations();
        Expectation GetExpectationById(Guid CohortId, Guid FacetId);
    }
}
