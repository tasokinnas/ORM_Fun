using System;


namespace Entities.DataTransferObjects
{
    public class ExpectationDto
    {
        public string Description { get; set; }

        public Guid CohortId { get; set; }

        public Guid FacetId { get; set; }
    }
}
