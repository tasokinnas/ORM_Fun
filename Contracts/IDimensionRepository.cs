// <copyright file="IDimensionRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Contracts
{
    using System;
    using System.Collections.Generic;
    using Entities.Models;

    public interface IDimensionRepository : IRepositoryBase<Dimension>
    {
        IEnumerable<Dimension> GetAllDimensions();

        Dimension GetDimensionById(Guid id);

        IEnumerable<Dimension> DimensionsByGfGroup(Guid gfGroupId);
    }
}
