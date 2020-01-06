using System;

namespace Entities.DataTransferObjects
{
    public class ExpectationDTO
    {
        public string Description { get; set; }

        public Guid Cohort_Id { get; set; }

        public Guid Facet_Id { get; set; }
    }
}
