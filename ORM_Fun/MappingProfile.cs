// <copyright file="MappingProfile.cs" company="Allata, LLC">
// Copyright (c) Allata, LLC. All rights reserved.
// </copyright>

namespace ORM_Fun
{
    using AutoMapper;
    using Entities.DataTransferObjects;
    using Entities.Models;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Cohort, CohortDto>();

            this.CreateMap<GfGroup, GfGroupDto>();
            this.CreateMap<GfGroupCreateDto, GfGroup>();
            this.CreateMap<GfGroupUpdateDto, GfGroup>();

            this.CreateMap<Dimension, DimensionDto>();

            this.CreateMap<Facet, FacetDto>();

            this.CreateMap<Expectation, ExpectationDto>();
        }
    }
}
