using System;

namespace Entities.DataTransferObjects
{
    public class CohortDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid Next_Cohort_Id { get; set; }

    }
}
