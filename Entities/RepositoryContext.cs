using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext: DbContext
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Expectation>()
                .HasKey(e => new { e.CohortId, e.FacetId });
        }

    }
}
