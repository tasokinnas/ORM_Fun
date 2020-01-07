using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface IDimensionRepository : IRepositoryBase<Dimension>
    {
        IEnumerable<Dimension> GetAllDimensions();
        Dimension GetDimensionById(Guid id);
    }
}
