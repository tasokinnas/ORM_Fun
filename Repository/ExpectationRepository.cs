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

        public Expectation GetExpectationById(Guid Cohort_Id, Guid Facet_Id)
        {
            return FindByCondition(expectation => 
            expectation.Cohort_Id.Equals(Cohort_Id) &&
            expectation.Facet_Id.Equals(Facet_Id)
            ).FirstOrDefault();
        }    
    }
}
