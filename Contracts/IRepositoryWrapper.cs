namespace Contracts
{
    public interface IRepositoryWrapper
    {
        ICohortRepository Cohort { get; }
        IGfGroupRepository GfGroup { get; }
        IDimensionRepository Dimension { get; }
        IFacetRepository Facet { get; }
        IExpectationRepository Expectation { get; }
        void Save();
    }
}
