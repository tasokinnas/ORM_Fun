using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class FacetRepository : RepositoryBase<Facet>, IFacetRepository
    {
        public FacetRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Facet> GetAllFacets()
        {
            return FindAll().OrderBy(f => f.Name).ToList();
        }

        public Facet GetFacetById(Guid Id)
        {
            return FindByCondition(facet => facet.Id.Equals(Id)).FirstOrDefault();
        }
    }
}
