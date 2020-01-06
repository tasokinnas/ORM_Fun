using System;
using System.Collections.Generic;

namespace Entities.DataTransferObjects
{
    public class GfGroupDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<DimensionDto> Dimensions { get; set; } 
    }
}
