// <copyright file="GfGroupDto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Entities.DataTransferObjects
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// DTO for GF Group.
    /// </summary>
    public class GfGroupDto
    {
        /// <summary>
        /// Gets or sets id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets list of dimensions.
        /// </summary>
        public IEnumerable<DimensionDto> Dimensions { get; set; }
    }
}
