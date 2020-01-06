using System;
using System.Collections.Generic;

namespace Entities.DataTransferObjects
{
    public class DimensionDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid GfGroupId { get; set; }

        public IEnumerable<FacetDto> Facets { get; set; }
    }
}
