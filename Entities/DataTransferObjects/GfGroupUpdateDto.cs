// <copyright file="GfGroupUpdateDto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Entities.DataTransferObjects
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// DTO for updating group objects.
    /// </summary>
    public class GfGroupUpdateDto
    {
        /// <summary>
        /// Gets or sets id.
        /// </summary>
        [Required(ErrorMessage = "Id is required")]
        [StringLength(50, ErrorMessage = "Id can't be longer than 50 characters")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name can't be longer than 50 characters")]
        public string Name { get; set; }
    }
}
