// <copyright file="ExpectationDto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Entities.DataTransferObjects
{
    using System;
    using System.Collections.Generic;

    public class ExpectationDto
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public IEnumerable<CohortFacetExpectationDto> CohortFacetExpectations { get; set; }
    }
}
