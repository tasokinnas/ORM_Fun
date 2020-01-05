using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class FacetRepository : RepositoryBase<Facet>, IFacetRepository
    {
        public FacetRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
