// <copyright file="CohortRepository.cs" company="PlaceholderCompany">
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

    public class CohortRepository : RepositoryBase<Cohort>, ICohortRepository
    {
        public CohortRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Cohort> GetAllCohorts()
        {
            return this.FindAll().OrderBy(c => c.Name).ToList();
        }

        public Cohort GetCohortById(Guid id)
        {
            return this.FindByCondition(cohort => cohort.Id.Equals(id)).FirstOrDefault();
        }
    }
}
