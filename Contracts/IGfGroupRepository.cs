// <copyright file="IGfGroupRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Contracts
{
    using System;
    using System.Collections.Generic;
    using Entities.Models;

    /// <summary>
    /// repo interface for group controller.
    /// </summary>
    public interface IGfGroupRepository : IRepositoryBase<GfGroup>
    {
        /// <summary>
        /// get all groups.
        /// </summary>
        /// <returns>list of groups.</returns>
        IEnumerable<GfGroup> GetAllGfGroups();

        /// <summary>
        /// get group by id.
        /// </summary>
        /// <param name="id">group id.</param>
        /// <returns>a group based on id.</returns>
        GfGroup GetGfGroupById(Guid id);

        /// <summary>
        /// dimensions based on a group id.
        /// </summary>
        /// <param name="id">group id.</param>
        /// <returns>group and it's child dimenstions.</returns>
        GfGroup GetGfGroupWithDimensions(Guid id);

        /// <summary>
        /// create a new group object.
        /// </summary>
        /// <param name="gfGroup">group object.</param>
        void CreateGfGroup(GfGroup gfGroup);

        /// <summary>
        /// update a group object.
        /// </summary>
        /// <param name="gfGroup">group object.</param>
        void UpdateGfGroup(GfGroup gfGroup);
    }
}
