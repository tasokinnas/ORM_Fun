// <copyright file="ICohortRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Contracts
{
    using System;
    using System.Collections.Generic;
    using Entities.Models;

    /// <summary>
    /// Interface for Cohort Repository.
    /// </summary>
    public interface ICohortRepository : IRepositoryBase<Cohort>
    {
        /// <summary>
        /// Get all Cohorts.
        /// </summary>
        /// <returns>
        /// Returns list of cohorts.
        /// </returns>
        IEnumerable<Cohort> GetAllCohorts();

        /// <summary>
        /// Get Cohort by id.
        /// </summary>
        /// <param name="id">
        /// The id of a cohort.
        /// </param>
        /// <returns>
        /// Returns cohort detail for a given id.
        /// </returns>
        Cohort GetCohortById(Guid id);
    }
}
