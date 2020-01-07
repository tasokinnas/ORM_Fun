// <copyright file="IFacetRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Contracts
{
    using System;
    using System.Collections.Generic;
    using Entities.Models;

    public interface IFacetRepository : IRepositoryBase<Facet>
    {
        IEnumerable<Facet> GetAllFacets();

        Facet GetFacetById(Guid id);
    }
}
