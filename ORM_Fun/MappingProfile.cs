using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace ORM_Fun
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Cohort
            CreateMap<Cohort, CohortDto>();

            //Group
            CreateMap<GfGroup, GfGroupDto>();
            CreateMap<GfGroupCreateDto, GfGroup>();


            // Dimension
            CreateMap<Dimension, DimensionDto>();

            //Facet
            CreateMap<Facet, FacetDto>();

            //Expectation
            CreateMap<Expectation, ExpectationDto>();
        }
    }
}
