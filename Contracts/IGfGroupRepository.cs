using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface IGfGroupRepository : IRepositoryBase<GfGroup>
    {
        IEnumerable<GfGroup> GetAllGfGroups();
        GfGroup GetGfGroupById(Guid id);
        GfGroup GetGfGroupWithDimensions(Guid id);
        void CreateGfGroup(GfGroup gfGroup);
        void UpdateGfGroup(GfGroup gfGroup);
    }
}
