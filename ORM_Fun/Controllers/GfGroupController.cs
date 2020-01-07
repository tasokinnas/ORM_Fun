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
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public GfGroupController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            this._logger = logger;
            this._repository = repository;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllGfGroups()
        {
            try
            {
                var gfGroups = this._repository.GfGroup.GetAllGfGroups();
                this._logger.LogInfo($"Returned all GF Groups from database.");

                var gfGroupResult = this._mapper.Map<IEnumerable<GfGroupDto>>(gfGroups);

                return this.Ok(gfGroupResult);
            }
            catch (Exception ex)
            {
                this._logger.LogError($"Something went wrong inside GetAllGfGroups action: {ex.Message}");
                return this.StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "GfGroupById")]
        public IActionResult GetGfGroupById(Guid id)
        {
            try
            {
                var gfGroup = this._repository.GfGroup.GetGfGroupById(id);
                if (gfGroup == null)
                {
                    this._logger.LogError($"GF Group with id: {id}, hasn't been found in db.");
                    return this.NotFound();
                }
                else
                {
                    this._logger.LogInfo($"Returned GF Group with id: {id}");

                    var gfGroupResult = this._mapper.Map<GfGroupDto>(gfGroup);
                    return this.Ok(gfGroupResult);
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError($"Something went wrong inside GetGF_GroupById action: {ex.Message}");
                return this.StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/dimension")]
        public IActionResult GetGfGroupWithDimensions(Guid id)
        {
            try
            {
                var gfGroup = this._repository.GfGroup.GetGfGroupWithDimensions(id);

                if (gfGroup == null)
                {
                    this._logger.LogError($"GF Group with id: {id}, hasn't been found in db.");
                    return this.NotFound();
                }
                else
                {
                    this._logger.LogInfo($"Returned GF Group with id: {id}");

                    var gfGroupResult = this._mapper.Map<GfGroupDto>(gfGroup);
                    return this.Ok(gfGroupResult);
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError($"Something went wrong inside GetGfGroupWithDimensions action: {ex.Message}");
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
                    this._logger.LogError("Owner object sent from client is null.");
                    return this.BadRequest("Owner object is null");
                }

                if (!this.ModelState.IsValid)
                {
                    this._logger.LogError("Invalid owner object sent from client.");
                    return this.BadRequest("Invalid model object");
                }

                var gfGroupEntity = this._mapper.Map<GfGroup>(gfGroup);

                this._repository.GfGroup.CreateGfGroup(gfGroupEntity);
                this._repository.Save();

                var createdGfGroup = this._mapper.Map<GfGroupDto>(gfGroupEntity);

                return this.CreatedAtRoute("GfGroupById", new { id = createdGfGroup.Id }, createdGfGroup);
            }
            catch (Exception ex)
            {
                this._logger.LogError($"Something went wrong inside CreateGfGroup action: {ex.Message}");
                return this.StatusCode(500, "Internal server error");
            }
        }
    }
}