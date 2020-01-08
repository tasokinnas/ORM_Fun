// <copyright file="CohortFacetExpectation.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Entities.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CohortFacetExpectation")]
    public class CohortFacetExpectation
    {
        [Required(ErrorMessage = "Id is required")]
        [StringLength(50, ErrorMessage = "Id can't be longer than 50 characters")]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Cohort))]
        [Required(ErrorMessage = "CohortId is required")]
        [StringLength(50, ErrorMessage = "Id can't be longer than 50 characters")]
        public Guid CohortId { get; set; }

        public Cohort Cohort { get; set; }

        [ForeignKey(nameof(Facet))]
        [Required(ErrorMessage = "FacetId is required")]
        [StringLength(50, ErrorMessage = "Id can't be longer than 50 characters")]
        public Guid FacetId { get; set; }

        public Facet Facet { get; set; }

        [ForeignKey(nameof(Expectation))]
        [Required(ErrorMessage = "ExpectationId is required")]
        [StringLength(50, ErrorMessage = "Id can't be longer than 50 characters")]
        public Guid ExpectationId { get; set; }

        public Expectation Expectation { get; set; }
    }
}
