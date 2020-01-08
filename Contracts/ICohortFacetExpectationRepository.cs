// <copyright file="IGfGroupRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Contracts
{
    using System;
    using System.Collections.Generic;
    using Entities.Models;

    public interface ICohortFacetExpectationRepository : IRepositoryBase<CohortFacetExpectation>
    {
        /// <summary>
        /// get all cohortFacetExpectations.
        /// </summary>
        /// <returns>list of cohortFacetExpectations.</returns>
        IEnumerable<CohortFacetExpectation> GetCohortFacetExpectations();

        /// <summary>
        /// get cohortFacetExpectation by id.
        /// </summary>
        /// <param name="id">cohortFacetExpectation id.</param>
        /// <returns>a cohortFacetExpectation object based on id.</returns>
        CohortFacetExpectation GetCohortFacetExpectationById(Guid id);
    }
}
