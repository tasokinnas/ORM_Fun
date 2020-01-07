// <copyright file="RepositoryWrapper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Repository
{
    using Contracts;
    using Entities;

    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private ICohortRepository _cohort;
        private IGfGroupRepository _gfGroup;
        private IDimensionRepository _dimension;
        private IFacetRepository _facet;
        private IExpectationRepository _expectation;

        public ICohortRepository Cohort
        {
            get
            {
                if (this._cohort == null)
                {
                    this._cohort = new CohortRepository(this._repoContext);
                }

                return this._cohort;
            }
        }

        public IGfGroupRepository GfGroup
        {
            get
            {
                if (this._gfGroup == null)
                {
                    this._gfGroup = new GfGroupRepository(this._repoContext);
                }

                return this._gfGroup;
            }
        }

        public IDimensionRepository Dimension
        {
            get
            {
                if (this._dimension == null)
                {
                    this._dimension = new DimensionRepository(this._repoContext);
                }

                return this._dimension;
            }
        }

        public IFacetRepository Facet
        {
            get
            {
                if (this._facet == null)
                {
                    this._facet = new FacetRepository(this._repoContext);
                }

                return this._facet;
            }
        }

        public IExpectationRepository Expectation
        {
            get
            {
                if (this._expectation == null)
                {
                    this._expectation = new ExpectationRepository(this._repoContext);
                }

                return this._expectation;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            this._repoContext = repositoryContext;
        }

        public void Save()
        {
            this._repoContext.SaveChanges();
        }
    }
}
