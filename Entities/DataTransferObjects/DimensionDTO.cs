// <copyright file="DimensionDto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Entities.DataTransferObjects
{
    using System;
    using System.Collections.Generic;

    public class DimensionDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid GfGroupId { get; set; }

        public IEnumerable<FacetDto> Facets { get; set; }
    }
}
