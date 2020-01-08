// <copyright file="GfGroupRepository.cs" company="PlaceholderCompany">
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
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// repo interface for cohortFacetExpectation controller.
    /// </summary>
    public class CohortFacetExpectationRepository : RepositoryBase<CohortFacetExpectation>, ICohortFacetExpectationRepository
    {
        public CohortFacetExpectationRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<CohortFacetExpectation> GetCohortFacetExpectations()
        {
            return this.FindAll().OrderBy(c => c.Id).ToList();
        }

        public CohortFacetExpectation GetCohortFacetExpectationById(Guid id)
        {
            return this.FindByCondition(g => g.Id.Equals(id)).FirstOrDefault();
        }


    }
}
