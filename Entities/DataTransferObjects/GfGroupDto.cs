// <copyright file="GfGroupDto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Entities.DataTransferObjects
{
    using System;
    using System.Collections.Generic;

    public class GfGroupDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<DimensionDto> Dimensions { get; set; }
    }
}
