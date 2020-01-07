// <copyright file="CohortController.cs" company="Allata, LLC">
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

    [Route("cohort")]
    [ApiController]
    public class CohortController : ControllerBase
    {
        private ILoggerManager logger;
        private IRepositoryWrapper repository;
        private IMapper mapper;

        public CohortController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            this.logger = logger;
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllCohorts()
        {
            try
            {
                var cohorts = this.repository.Cohort.GetAllCohorts();
                this.logger.LogInfo($"Returned all cohorts from database.");

                var cohortResult = this.mapper.Map<IEnumerable<CohortDto>>(cohorts);

                return this.Ok(cohortResult);
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Something went wrong inside GetAllCohorts action: {ex.Message}");
                return this.StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCohortById(Guid id)
        {
            try
            {
                var cohort = this.repository.Cohort.GetCohortById(id);
                if (cohort == null)
                {
                    this.logger.LogError($"Cohrt with id: {id}, hasn't been found in db.");
                    return this.NotFound();
                }
                else
                {
                    this.logger.LogInfo($"Returned cohort with id: {id}");

                    var cohortResult = this.mapper.Map<CohortDto>(cohort);
                    return this.Ok(cohortResult);
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Something went wrong inside GetOwnerById action: {ex.Message}");
                return this.StatusCode(500, "Internal server error");
            }
        }
    }
}