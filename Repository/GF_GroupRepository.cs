using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class GF_GroupRepository : RepositoryBase<GF_Group>, IGF_GroupRepository
    {
        public GF_GroupRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        public IEnumerable<GF_Group> GetAllGF_Groups()
        {
            return FindAll().OrderBy(g => g.Name).ToList();
        }

        public GF_Group GetGF_GroupById(Guid Id)
        {
            return FindByCondition(gf_group => gf_group.Id.Equals(Id)).FirstOrDefault();
        }
    }
}
