// <copyright file="Facet.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Facet")]
    public class Facet
    {
        [Required(ErrorMessage = "Id is required")]
        [StringLength(50, ErrorMessage = "Id can't be longer than 50 characters")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name can't be longer than 50 characters")]
        public string Name { get; set; }

        [ForeignKey(nameof(Dimension))]
        public Guid DimensionId { get; set; }

        public Dimension Dimension { get; set; }

        public ICollection<CohortFacetExpectation> CohortFacetExpectations { get; set; }
    }
}
