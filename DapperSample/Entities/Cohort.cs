using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperSample.Entities
{
    public class Cohort
    {
        public Guid Id { get; set; }


        public string Name { get; set; }

        public int Rank { get; set; }

        public Guid NextCohortId { get; set; }
    }
}
