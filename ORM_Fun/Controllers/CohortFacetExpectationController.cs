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

    [Route("cohortfacetexpectation")]
    [ApiController]
    public class CohortFacetExpectationController : ControllerBase
    {
        private ILoggerManager logger;
        private IRepositoryWrapper repository;
        private IMapper mapper;

        public CohortFacetExpectationController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            this.logger = logger;
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCohortFacetExpectations()
        {
            try
            {
                var cohortFacetExpectations = this.repository.CohortFacetExpectation.GetCohortFacetExpectations();
                this.logger.LogInfo($"Returned all CohortFacetExpectations from database.");

                var cohortFacetExpectationResult = this.mapper.Map<IEnumerable<CohortFacetExpectationDto>>(cohortFacetExpectations);

                return this.Ok(cohortFacetExpectationResult);
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Something went wrong inside GetCohortFacetExpectations action: {ex.Message}");
                return this.StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "GetCohortFacetExpectationById")]
        public IActionResult GetCohortFacetExpectationById(Guid id)
        {
            try
            {
                var cohortFacetExpectation = this.repository.CohortFacetExpectation.GetCohortFacetExpectationById(id);
                if (cohortFacetExpectation == null)
                {
                    this.logger.LogError($"CohortFacetExpectation with id: {id}, hasn't been found in db.");
                    return this.NotFound();
                }
                else
                {
                    this.logger.LogInfo($"Returned CohortFacetExpectation with id: {id}");

                    var cohortFacetExpectationResult = this.mapper.Map<CohortFacetExpectationDto>(cohortFacetExpectation);
                    return this.Ok(cohortFacetExpectationResult);
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Something went wrong inside GetCohortFacetExpectationById action: {ex.Message}");
                return this.StatusCode(500, "Internal server error");
            }
        }
    }
}