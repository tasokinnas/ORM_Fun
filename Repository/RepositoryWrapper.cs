// <copyright file="RepositoryWrapper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Repository
{
    using Contracts;
    using Entities;

    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext repoContext;
        private ICohortRepository cohort;
        private IGfGroupRepository gfGroup;
        private IDimensionRepository dimension;
        private IFacetRepository facet;
        private IExpectationRepository expectation;
        private ICohortFacetExpectationRepository cohortFacetExpectation;

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            this.repoContext = repositoryContext;
        }

        public ICohortRepository Cohort
        {
            get
            {
                if (this.cohort == null)
                {
                    this.cohort = new CohortRepository(this.repoContext);
                }

                return this.cohort;
            }
        }

        public IGfGroupRepository GfGroup
        {
            get
            {
                if (this.gfGroup == null)
                {
                    this.gfGroup = new GfGroupRepository(this.repoContext);
                }

                return this.gfGroup;
            }
        }

        public IDimensionRepository Dimension
        {
            get
            {
                if (this.dimension == null)
                {
                    this.dimension = new DimensionRepository(this.repoContext);
                }

                return this.dimension;
            }
        }

        public IFacetRepository Facet
        {
            get
            {
                if (this.facet == null)
                {
                    this.facet = new FacetRepository(this.repoContext);
                }

                return this.facet;
            }
        }

        public IExpectationRepository Expectation
        {
            get
            {
                if (this.expectation == null)
                {
                    this.expectation = new ExpectationRepository(this.repoContext);
                }

                return this.expectation;
            }
        }

        public ICohortFacetExpectationRepository CohortFacetExpectation
        {
            get
            {
                if (this.cohortFacetExpectation == null)
                {
                    this.cohortFacetExpectation = new CohortFacetExpectationRepository(this.repoContext);
                }

                return this.cohortFacetExpectation;
            }
        }



        public void Save()
        {
            this.repoContext.SaveChanges();
        }
    }
}
