// <copyright file="IRepositoryWrapper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

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
