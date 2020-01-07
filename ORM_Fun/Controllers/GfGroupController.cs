// <copyright file="GfGroupController.cs" company="Allata, LLC">
// Copyright (c) Allata, LLC. All rights reserved.
// </copyright>

namespace ORM_Fun.Controllers
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Contracts;
    using Entities.DataTransferObjects;
    using Entities.Models;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// group controller.
    /// </summary>
    [Route("gfgroup")]
    [ApiController]
    public class GfGroupController : ControllerBase
    {
        private ILoggerManager logger;
        private IRepositoryWrapper repository;
        private IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GfGroupController"/> class.
        /// </summary>
        /// <param name="logger">the logger object.</param>
        /// <param name="repository">the repository object.</param>
        /// <param name="mapper">the mapper object.</param>
        public GfGroupController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            this.logger = logger;
            this.repository = repository;
            this.mapper = mapper;
        }

        /// <summary>
        /// get all groups api call.
        /// </summary>
        /// <returns>list of groups.</returns>
        [HttpGet]
        public IActionResult GetAllGfGroups()
        {
            try
            {
                var gfGroups = this.repository.GfGroup.GetAllGfGroups();
                this.logger.LogInfo($"Returned all GF Groups from database.");

                var gfGroupResult = this.mapper.Map<IEnumerable<GfGroupDto>>(gfGroups);

                return this.Ok(gfGroupResult);
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Something went wrong inside GetAllGfGroups action: {ex.Message}");
                return this.StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// get group by id api call.
        /// </summary>
        /// <param name="id">group id.</param>
        /// <returns>returns a group object by id.</returns>
        [HttpGet("{id}", Name = "GfGroupById")]
        public IActionResult GetGfGroupById(Guid id)
        {
            try
            {
                var gfGroup = this.repository.GfGroup.GetGfGroupById(id);
                if (gfGroup == null)
                {
                    this.logger.LogError($"GF Group with id: {id}, hasn't been found in db.");
                    return this.NotFound();
                }
                else
                {
                    this.logger.LogInfo($"Returned GF Group with id: {id}");

                    var gfGroupResult = this.mapper.Map<GfGroupDto>(gfGroup);
                    return this.Ok(gfGroupResult);
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Something went wrong inside GetGF_GroupById action: {ex.Message}");
                return this.StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// get dimensions for a group.
        /// </summary>
        /// <param name="id">group id.</param>
        /// <returns>list of dimensions for a group based on group id.</returns>
        [HttpGet("{id}/dimension")]
        public IActionResult GetGfGroupWithDimensions(Guid id)
        {
            try
            {
                var gfGroup = this.repository.GfGroup.GetGfGroupWithDimensions(id);

                if (gfGroup == null)
                {
                    this.logger.LogError($"GF Group with id: {id}, hasn't been found in db.");
                    return this.NotFound();
                }
                else
                {
                    this.logger.LogInfo($"Returned GF Group with id: {id}");

                    var gfGroupResult = this.mapper.Map<GfGroupDto>(gfGroup);
                    return this.Ok(gfGroupResult);
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Something went wrong inside GetGfGroupWithDimensions action: {ex.Message}");
                return this.StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// create a new group object api.
        /// </summary>
        /// <param name="gfGroup">group object.</param>
        /// <returns>newly created group object.</returns>
        [HttpPost]
        public IActionResult CreateGfGroup([FromBody]GfGroupCreateDto gfGroup)
        {
            try
            {
                if (gfGroup == null)
                {
                    this.logger.LogError("Owner object sent from client is null.");
                    return this.BadRequest("Owner object is null");
                }

                if (!this.ModelState.IsValid)
                {
                    this.logger.LogError("Invalid owner object sent from client.");
                    return this.BadRequest("Invalid model object");
                }

                var gfGroupEntity = this.mapper.Map<GfGroup>(gfGroup);

                this.repository.GfGroup.CreateGfGroup(gfGroupEntity);
                this.repository.Save();

                var createdGfGroup = this.mapper.Map<GfGroupDto>(gfGroupEntity);

                return this.CreatedAtRoute("GfGroupById", new { id = createdGfGroup.Id }, createdGfGroup);
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Something went wrong inside CreateGfGroup action: {ex.Message}");
                return this.StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// update group object api.
        /// </summary>
        /// <param name="id">group id.</param>
        /// <param name="gfGroup">group object.</param>
        /// <returns>updated group object.</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateGfGroup(Guid id, [FromBody]GfGroupUpdateDto gfGroup)
        {
            try
            {
                if (gfGroup == null)
                {
                    this.logger.LogError("GfGroup object sent from client is null.");
                    return this.BadRequest("GfGroup object is null");
                }

                if (!this.ModelState.IsValid)
                {
                    this.logger.LogError("Invalid gfGroup object sent from client.");
                    return this.BadRequest("Invalid model object");
                }

                var gfGroupEntity = this.repository.GfGroup.GetGfGroupById(id);
                if (gfGroupEntity == null)
                {
                    this.logger.LogError($"GfGroup with id: {id}, hasn't been found in db.");
                    return this.NotFound();
                }

                this.mapper.Map(gfGroup, gfGroupEntity);

                this.repository.GfGroup.UpdateGfGroup(gfGroupEntity);
                this.repository.Save();

                return this.NoContent();
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Something went wrong inside UpdateGfGroup action: {ex.Message}");
                return this.StatusCode(500, "Internal server error");
            }
        }
    }
}