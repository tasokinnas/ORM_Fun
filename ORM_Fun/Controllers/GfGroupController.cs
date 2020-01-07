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

    [Route("gfgroup")]
    [ApiController]
    public class GfGroupController : ControllerBase
    {
        private ILoggerManager logger;
        private IRepositoryWrapper repository;
        private IMapper mapper;

        public GfGroupController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            this.logger = logger;
            this.repository = repository;
            this.mapper = mapper;
        }

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
    }
}