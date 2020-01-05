using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class CohortRepository : RepositoryBase<Cohort>, ICohortRepository
    {
        public CohortRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Cohort> GetAllCohorts()
        {
            return FindAll().OrderBy(c => c.Name).ToList(); 
        }

        public Cohort GetCohortById(Guid Id)
        {
            return FindByCondition(cohort => cohort.Id.Equals(Id)).FirstOrDefault();
        }
    }
}
