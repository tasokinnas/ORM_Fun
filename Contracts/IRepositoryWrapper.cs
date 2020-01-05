namespace Contracts
{
    public interface IRepositoryWrapper
    {
        ICohortRepository Cohort { get; }
        IGF_GroupRepository GF_Group { get; }
        IDimensionRepository Dimension { get; }
        IFacetRepository Facet { get; }
        IExpectationRepository Expectation { get; }
        void Save();
    }
}
