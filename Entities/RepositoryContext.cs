// <copyright file="RepositoryContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Entities
{
    using Entities.Models;
    using Microsoft.EntityFrameworkCore;

    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Cohort> Cohorts { get; set; }

        public DbSet<GfGroup> GfGroups { get; set; }

        public DbSet<Dimension> Dimensions { get; set; }

        public DbSet<Facet> Facets { get; set; }

        public DbSet<Expectation> Expectations { get; set; }

        public DbSet<CohortFacetExpectation> CohortFacetExpectations { get; set; }

    }
}
