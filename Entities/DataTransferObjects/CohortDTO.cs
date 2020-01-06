using System;
using System.Collections.Generic;

namespace Entities.DataTransferObjects
{
    public class CohortDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Rank { get; set; }

        public Guid NextCohortId { get; set; }

        public IEnumerable<ExpectationDto> Expectations { get; set; }

    }
}
