using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class GfGroupRepository : RepositoryBase<GfGroup>, IGfGroupRepository
    {
        public GfGroupRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        public IEnumerable<GfGroup> GetAllGfGroups()
        {
            return FindAll().OrderBy(g => g.Name).ToList();
        }

        public GfGroup GetGfGroupById(Guid Id)
        {
            return FindByCondition(g => g.Id.Equals(Id)).FirstOrDefault();
        }

        public GfGroup GetGfGroupWithDimensions(Guid Id)
        {
            var result = FindByCondition(g => g.Id.Equals(Id))
                .Include(g => g.Dimensions)
                .FirstOrDefault();
            return result;
        }

        public void CreateGfGroup(GfGroup gfGroup)
        {
            Create(gfGroup);
        }

    }
}
