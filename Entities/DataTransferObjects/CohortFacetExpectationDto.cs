// <copyright file="GfGroupDto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Entities.DataTransferObjects
{
    using System;
    using System.Collections.Generic;

    public class CohortFacetExpectationDto
    {
        public Guid Id { get; set; }

        public Guid CohortId { get; set; }

        public Guid FacetId { get; set; }

        public Guid ExpectationId { get; set; }
    }
}
