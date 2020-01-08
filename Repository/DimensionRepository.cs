// <copyright file="DimensionRepository.cs" company="PlaceholderCompany">
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

    public class DimensionRepository : RepositoryBase<Dimension>, IDimensionRepository
    {
        public DimensionRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Dimension> GetAllDimensions()
        {
            return this.FindAll().OrderBy(d => d.Name).ToList();
        }

        public Dimension GetDimensionById(Guid id)
        {
            return this.FindByCondition(dimension => dimension.Id.Equals(id)).FirstOrDefault();
        }

        public IEnumerable<Dimension> DimensionsByGfGroup(Guid gfGroupID)
        {
            return this.FindByCondition(d => d.GfGroupId.Equals(gfGroupID)).ToList();
        }
    }
}
