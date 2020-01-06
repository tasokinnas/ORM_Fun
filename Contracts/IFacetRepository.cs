using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface IFacetRepository : IRepositoryBase<Facet>
    {
        IEnumerable<Facet> GetAllFacets();
        Facet GetFacetById(Guid Id);
    }
}
