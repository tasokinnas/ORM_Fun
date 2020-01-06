using System;

namespace Entities.DataTransferObjects
{
    public class DimensionDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid GF_Group_Id { get; set; }
    }
}
