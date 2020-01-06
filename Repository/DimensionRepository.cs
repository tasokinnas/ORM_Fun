using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class DimensionRepository : RepositoryBase<Dimension>, IDimensionRepository
    {
        public DimensionRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Dimension> GetAllDimensions()
        {
            return FindAll().OrderBy(d => d.Name).ToList();
        }

        public Dimension GetDimensionById(Guid Id)
        {
            return FindByCondition(dimension => dimension.Id.Equals(Id)).FirstOrDefault();
        }
    }
}
