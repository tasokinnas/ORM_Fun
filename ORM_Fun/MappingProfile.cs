using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using System.Linq;

namespace ORM_Fun
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cohort, CohortDTO>();

            CreateMap<GF_Group, GF_GroupDTO>();

            CreateMap<Dimension, DimensionDTO>();

            CreateMap<Facet, FacetDTO>();

            CreateMap<Expectation, ExpectationDTO>();


        }
    }
}
