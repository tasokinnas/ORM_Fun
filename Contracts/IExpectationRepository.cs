// <copyright file="IExpectationRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Contracts
{
    using System;
    using System.Collections.Generic;
    using Entities.Models;

    public interface IExpectationRepository : IRepositoryBase<Expectation>
    {
        IEnumerable<Expectation> GetAllExpectations();

        Expectation GetExpectationById(Guid cohortId, Guid facetId);
    }
}
