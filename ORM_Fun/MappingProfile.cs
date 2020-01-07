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
            // Cohort
            this.CreateMap<Cohort, CohortDto>();

            //Group
            this.CreateMap<GfGroup, GfGroupDto>();
            this.CreateMap<GfGroupCreateDto, GfGroup>();
            this.CreateMap<GfGroupUpdateDto, GfGroup>();

            // Dimension
            this.CreateMap<Dimension, DimensionDto>();

            //Facet
            this.CreateMap<Facet, FacetDto>();

            //Expectation
            this.CreateMap<Expectation, ExpectationDto>();
        }
    }
}
