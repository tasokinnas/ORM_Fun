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
        }
    }
}
