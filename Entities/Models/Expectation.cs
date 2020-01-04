using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Expectation")]
    public class Expectation
    {
        [Required(ErrorMessage = "Id is required")]
        [StringLength(50, ErrorMessage = "Id can't be longer than 50 characters")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name can't be longer than 50 characters")]
        public string Description { get; set; }

        [ForeignKey(nameof(Facet))]
        public Guid Facet_Id { get; set; }
        public Facet Facet { get; set; }

        [ForeignKey(nameof(Cohort))]
        public Guid Cohort_Id { get; set; }
        public Cohort Cohort { get; set; }
    }
}
