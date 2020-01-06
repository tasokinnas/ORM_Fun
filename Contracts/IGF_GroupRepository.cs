using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface IGF_GroupRepository : IRepositoryBase<GF_Group>
    {
        IEnumerable<GF_Group> GetAllGF_Groups();
        GF_Group GetGF_GroupById(Guid Id);

        GF_Group GetGF_GroupWithDimensions(Guid Id);
    }
}
