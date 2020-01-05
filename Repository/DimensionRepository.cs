using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class DimensionRepository : RepositoryBase<Dimension>, IDimensionRepository
    {
        public DimensionRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
