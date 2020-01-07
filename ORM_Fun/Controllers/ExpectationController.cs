// <copyright file="ExpectationController.cs" company="Allata, LLC">
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

    [Route("expectation")]
    [ApiController]
    public class ExpectationController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public ExpectationController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            this._logger = logger;
            this._repository = repository;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllExpectations()
        {
            try
            {
                var expectations = this._repository.Expectation.GetAllExpectations();
                this._logger.LogInfo($"Returned all expectations from database.");

                var expectationResult = this._mapper.Map<IEnumerable<ExpectationDto>>(expectations);

                return this.Ok(expectationResult);
            }
            catch (Exception ex)
            {
                this._logger.LogError($"Something went wrong inside GetAllExpectations action: {ex.Message}");
                return this.StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{cohort_id}/{facet_id}")]
        public IActionResult GetExpectationById(Guid cohortId, Guid facetId)
        {
            try
            {
                var expectation = this._repository.Expectation.GetExpectationById(cohortId, facetId);
                if (expectation == null)
                {
                    this._logger.LogError($"Expectation with id: {cohortId} and {facetId}, hasn't been found in db.");
                    return this.NotFound();
                }
                else
                {
                    this._logger.LogInfo($"Returned expectation with ids: {cohortId}, {facetId}");

                    var expectationResult = this._mapper.Map<ExpectationDto>(expectation);
                    return this.Ok(expectationResult);
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError($"Something went wrong inside GetExpectationByIds action: {ex.Message}");
                return this.StatusCode(500, "Internal server error");
            }
        }
    }
}