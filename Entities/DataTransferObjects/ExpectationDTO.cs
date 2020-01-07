// <copyright file="ExpectationDto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Entities.DataTransferObjects
{
    using System;

    public class ExpectationDto
    {
        public string Description { get; set; }

        public Guid CohortId { get; set; }

        public Guid FacetId { get; set; }
    }
}
