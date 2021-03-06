﻿// <copyright file="CohortDto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Entities.DataTransferObjects
{
    using System;
    using System.Collections.Generic;

    public class CohortDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Rank { get; set; }

        public Guid NextCohortId { get; set; }

        public IEnumerable<CohortFacetExpectationDto> CohortFacetExpectations { get; set; }
    }
}
