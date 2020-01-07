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
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public DimensionController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            this._logger = logger;
            this._repository = repository;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllDimensions()
        {
            try
            {
                var dimensions = this._repository.Dimension.GetAllDimensions();
                this._logger.LogInfo($"Returned all dimensions from database.");

                var dimensionResult = this._mapper.Map<IEnumerable<DimensionDto>>(dimensions);

                return this.Ok(dimensionResult);
            }
            catch (Exception ex)
            {
                this._logger.LogError($"Something went wrong inside GetAllDimensions action: {ex.Message}");
                return this.StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetDimensionById(Guid id)
        {
            try
            {
                var dimension = this._repository.Dimension.GetDimensionById(id);
                if (dimension == null)
                {
                    this._logger.LogError($"Dimension with id: {id}, hasn't been found in db.");
                    return this.NotFound();
                }
                else
                {
                    this._logger.LogInfo($"Returned dimension with id: {id}");

                    var dimensionResult = this._mapper.Map<DimensionDto>(dimension);
                    return this.Ok(dimensionResult);
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError($"Something went wrong inside GetDimensionById action: {ex.Message}");
                return this.StatusCode(500, "Internal server error");
            }
        }
    }
}