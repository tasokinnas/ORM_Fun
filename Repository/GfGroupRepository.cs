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

    /// <summary>
    /// repo interface for group controller.
    /// </summary>
    public class GfGroupRepository : RepositoryBase<GfGroup>, IGfGroupRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GfGroupRepository"/> class.
        /// repository context.
        /// </summary>
        /// <param name="repositoryContext">repository context.</param>
        public GfGroupRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        /// <summary>
        /// get all groups.
        /// </summary>
        /// <returns>list of groups.</returns>
        public IEnumerable<GfGroup> GetAllGfGroups()
        {
            return this.FindAll().OrderBy(g => g.Name).ToList();
        }

        /// <summary>
        /// get group by id.
        /// </summary>
        /// <param name="id">group id.</param>
        /// <returns>a group based on id.</returns>
        public GfGroup GetGfGroupById(Guid id)
        {
            return this.FindByCondition(g => g.Id.Equals(id)).FirstOrDefault();
        }

        /// <summary>
        /// dimensions based on a group id.
        /// </summary>
        /// <param name="id">group id.</param>
        /// <returns>group and it's child dimenstions.</returns>
        public GfGroup GetGfGroupWithDimensions(Guid id)
        {
            var result = this.FindByCondition(g => g.Id.Equals(id))
                .Include(g => g.Dimensions)
                .FirstOrDefault();
            return result;
        }

        /// <summary>
        /// create a new group object.
        /// </summary>
        /// <param name="gfGroup">group object.</param>
        public void CreateGfGroup(GfGroup gfGroup)
        {
            this.Create(gfGroup);
        }

        /// <summary>
        /// update a group object.
        /// </summary>
        /// <param name="gfGroup">group object.</param>
        public void UpdateGfGroup(GfGroup gfGroup)
        {
            this.Update(gfGroup);
        }
    }
}
