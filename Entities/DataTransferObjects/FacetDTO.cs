using System;
using System.Collections.Generic;

namespace Entities.DataTransferObjects
{
    public class FacetDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid DimensionId { get; set; }

        public IEnumerable<ExpectationDto> Expectations { get; set; }
    }
}
