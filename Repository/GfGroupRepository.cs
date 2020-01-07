// <copyright file="GfGroupRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Entities;
    using Entities.Models;
    using Microsoft.EntityFrameworkCore;

    public class GfGroupRepository : RepositoryBase<GfGroup>, IGfGroupRepository
    {
        public GfGroupRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<GfGroup> GetAllGfGroups()
        {
            return this.FindAll().OrderBy(g => g.Name).ToList();
        }

        public GfGroup GetGfGroupById(Guid id)
        {
            return this.FindByCondition(g => g.Id.Equals(id)).FirstOrDefault();
        }

        public GfGroup GetGfGroupWithDimensions(Guid id)
        {
            var result = this.FindByCondition(g => g.Id.Equals(id))
                .Include(g => g.Dimensions)
                .FirstOrDefault();
            return result;
        }

        public void CreateGfGroup(GfGroup gfGroup)
        {
            this.Create(gfGroup);
        }

        public void UpdateGfGroup(GfGroup gfGroup)
        {
            this.Update(gfGroup);
        }
    }
}
