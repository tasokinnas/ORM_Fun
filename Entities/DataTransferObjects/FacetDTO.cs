// <copyright file="FacetDto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Entities.DataTransferObjects
{
    using System;
    using System.Collections.Generic;

    public class FacetDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid DimensionId { get; set; }

        public IEnumerable<ExpectationDto> Expectations { get; set; }
    }
}
