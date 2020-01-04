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
        public DbSet<Dimension> Dimensions { get; set; }
        public DbSet<Expectation> Expectations { get; set; }
        public DbSet<Facet> Facets { get; set; }
        public DbSet<GF_Group> GF_Groups { get; set; }
    }
}
