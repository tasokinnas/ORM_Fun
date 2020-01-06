using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class GF_GroupDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<DimensionDTO> Dimensions { get; set; } 
    }
}
