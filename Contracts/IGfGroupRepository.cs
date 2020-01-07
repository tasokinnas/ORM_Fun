// <copyright file="IGfGroupRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Contracts
{
    using System;
    using System.Collections.Generic;
    using Entities.Models;

    public interface IGfGroupRepository : IRepositoryBase<GfGroup>
    {
        IEnumerable<GfGroup> GetAllGfGroups();

        GfGroup GetGfGroupById(Guid id);

        GfGroup GetGfGroupWithDimensions(Guid id);

        void CreateGfGroup(GfGroup gfGroup);

        void UpdateGfGroup(GfGroup gfGroup);
    }
}
