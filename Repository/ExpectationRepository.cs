using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class ExpectationRepository : RepositoryBase<Expectation>, IExpectationRepository
    {
        public ExpectationRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Expectation> GetAllExpectations()
        {
            return FindAll().OrderBy(e => e.Description).ToList();
        }

        public Expectation GetExpectationById(Guid cohortId, Guid facetId)
        {
            return FindByCondition(expectation => 
            expectation.CohortId.Equals(cohortId) &&
            expectation.FacetId.Equals(facetId)
            ).FirstOrDefault();
        }    
    }
}
