using System;

namespace Entities.DataTransferObjects
{
    public class FacetDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid Dimension_Id { get; set; }
    }
}
