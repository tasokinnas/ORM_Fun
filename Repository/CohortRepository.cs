using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class CohortRepository : RepositoryBase<Cohort>, ICohortRepository
    {
        public CohortRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
