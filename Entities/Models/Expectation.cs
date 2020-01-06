using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Expectation")]
    public class Expectation
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name can't be longer than 50 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Cohort Id is required")]
        [ForeignKey(nameof(Cohort))]
        public Guid CohortId { get; set; }
        public Cohort Cohort { get; set; }

        [Required(ErrorMessage = "Facet Id is required")]
        [ForeignKey(nameof(Facet))]
        public Guid FacetId { get; set; }
        public Facet Facet { get; set; }

    }

   
}
