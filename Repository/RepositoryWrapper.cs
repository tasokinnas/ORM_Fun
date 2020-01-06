using Contracts;
using Entities;

namespace Repository
{
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
            get { 
                if(_cohort == null)
                {
                    _cohort = new CohortRepository(_repoContext);
                }
                return _cohort;
            }
        }

        public IGfGroupRepository GfGroup
        {
            get
            {
                if (_gfGroup == null)
                {
                    _gfGroup = new GfGroupRepository(_repoContext);
                }
                return _gfGroup;
            }
        }

        public IDimensionRepository Dimension
        {
            get
            {
                if (_dimension == null)
                {
                    _dimension = new DimensionRepository(_repoContext);
                }
                return _dimension;
            }
        }

        public IFacetRepository Facet
        {
            get
            {
                if (_facet == null)
                {
                    _facet = new FacetRepository(_repoContext);
                }
                return _facet;
            }
        }

        public IExpectationRepository Expectation
        {
            get
            {
                if (_expectation == null)
                {
                    _expectation = new ExpectationRepository(_repoContext);
                }
                return _expectation;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
