// <copyright file="DimensionController.cs" company="Allata, LLC">
// Copyright (c) Allata, LLC. All rights reserved.
// </copyright>

namespace ORM_Fun.Controllers
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Contracts;
    using Entities.DataTransferObjects;
    using Microsoft.AspNetCore.Mvc;

    [Route("dimension")]
    [ApiController]
    public class DimensionController : ControllerBase
    {
        private ILoggerManager logger;
        private IRepositoryWrapper repository;
        private IMapper mapper;

        public DimensionController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            this.logger = logger;
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllDimensions()
        {
            try
            {
                var dimensions = this.repository.Dimension.GetAllDimensions();
                this.logger.LogInfo($"Returned all dimensions from database.");

                var dimensionResult = this.mapper.Map<IEnumerable<DimensionDto>>(dimensions);

                return this.Ok(dimensionResult);
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Something went wrong inside GetAllDimensions action: {ex.Message}");
                return this.StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetDimensionById(Guid id)
        {
            try
            {
                var dimension = this.repository.Dimension.GetDimensionById(id);
                if (dimension == null)
                {
                    this.logger.LogError($"Dimension with id: {id}, hasn't been found in db.");
                    return this.NotFound();
                }
                else
                {
                    this.logger.LogInfo($"Returned dimension with id: {id}");

                    var dimensionResult = this.mapper.Map<DimensionDto>(dimension);
                    return this.Ok(dimensionResult);
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Something went wrong inside GetDimensionById action: {ex.Message}");
                return this.StatusCode(500, "Internal server error");
            }
        }
    }
}