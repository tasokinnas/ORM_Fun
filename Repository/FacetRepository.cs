// <copyright file="FacetRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Entities;
    using Entities.Models;

    public class FacetRepository : RepositoryBase<Facet>, IFacetRepository
    {
        public FacetRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Facet> GetAllFacets()
        {
            return this.FindAll().OrderBy(f => f.Name).ToList();
        }

        public Facet GetFacetById(Guid id)
        {
            return this.FindByCondition(facet => facet.Id.Equals(id)).FirstOrDefault();
        }
    }
}
