using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class ExpectationRepository : RepositoryBase<Expectation>, IExpectationRepository
    {
        public ExpectationRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
