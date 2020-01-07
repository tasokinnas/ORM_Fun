// <copyright file="MappingProfile.cs" company="Allata, LLC">
// Copyright (c) Allata, LLC. All rights reserved.
// </copyright>

namespace ORM_Fun
{
    using AutoMapper;
    using Entities.DataTransferObjects;
    using Entities.Models;

    /// <summary>
    /// profile mappers class.
    /// profile mappers for dto and model relationships.
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// </summary>
        public MappingProfile()
        {
            // cohort controller.
            this.CreateMap<Cohort, CohortDto>();

            // gfgroup controller.
            this.CreateMap<GfGroup, GfGroupDto>();
            this.CreateMap<GfGroupCreateDto, GfGroup>();
            this.CreateMap<GfGroupUpdateDto, GfGroup>();

            // dimension controller.
            this.CreateMap<Dimension, DimensionDto>();

            // facet controller.
            this.CreateMap<Facet, FacetDto>();

            // expectation controller.
            this.CreateMap<Expectation, ExpectationDto>();
        }
    }
}
