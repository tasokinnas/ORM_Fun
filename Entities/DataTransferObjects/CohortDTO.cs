// <copyright file="CohortDto.cs" company="Allata, LLC">
// Copyright (c) Allata, LLC. All rights reserved.
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

        public IEnumerable<ExpectationDto> Expectations { get; set; }

    }
}
