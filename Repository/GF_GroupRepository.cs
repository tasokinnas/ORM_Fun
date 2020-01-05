using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class GF_GroupRepository : RepositoryBase<GF_Group>, IGF_GroupRepository
    {
        public GF_GroupRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }
    }
}
