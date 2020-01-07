// <copyright file="ExpectationRepository.cs" company="PlaceholderCompany">
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

    public class ExpectationRepository : RepositoryBase<Expectation>, IExpectationRepository
    {
        public ExpectationRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Expectation> GetAllExpectations()
        {
            return this.FindAll().OrderBy(e => e.Description).ToList();
        }

        public Expectation GetExpectationById(Guid cohortId, Guid facetId)
        {
            return this.FindByCondition(expectation =>
            expectation.CohortId.Equals(cohortId) &&
            expectation.FacetId.Equals(facetId)).FirstOrDefault();
        }
    }
}
