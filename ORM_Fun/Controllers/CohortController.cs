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
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public CohortController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            this._logger = logger;
            this._repository = repository;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllCohorts()
        {
            try
            {
                var cohorts = this._repository.Cohort.GetAllCohorts();
                this._logger.LogInfo($"Returned all cohorts from database.");

                var cohortResult = this._mapper.Map<IEnumerable<CohortDto>>(cohorts);

                return this.Ok(cohortResult);
            }
            catch (Exception ex)
            {
                this._logger.LogError($"Something went wrong inside GetAllCohorts action: {ex.Message}");
                return this.StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCohortById(Guid id)
        {
            try
            {
                var cohort = this._repository.Cohort.GetCohortById(id);
                if (cohort == null)
                {
                    this._logger.LogError($"Cohrt with id: {id}, hasn't been found in db.");
                    return this.NotFound();
                }
                else
                {
                    this._logger.LogInfo($"Returned cohort with id: {id}");

                    var cohortResult = this._mapper.Map<CohortDto>(cohort);
                    return this.Ok(cohortResult);
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError($"Something went wrong inside GetOwnerById action: {ex.Message}");
                return this.StatusCode(500, "Internal server error");
            }
        }
    }
}