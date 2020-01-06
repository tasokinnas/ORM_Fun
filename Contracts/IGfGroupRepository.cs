using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface IGfGroupRepository : IRepositoryBase<GfGroup>
    {
        IEnumerable<GfGroup> GetAllGfGroups();
        GfGroup GetGfGroupById(Guid Id);
        GfGroup GetGfGroupWithDimensions(Guid Id);
        void CreateGfGroup(GfGroup gfGroup);
    }
}
