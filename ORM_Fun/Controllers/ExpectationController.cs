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
        private ILoggerManager logger;
        private IRepositoryWrapper repository;
        private IMapper mapper;

        public ExpectationController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            this.logger = logger;
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllExpectations()
        {
            try
            {
                var expectations = this.repository.Expectation.GetAllExpectations();
                this.logger.LogInfo($"Returned all expectations from database.");

                var expectationResult = this.mapper.Map<IEnumerable<ExpectationDto>>(expectations);

                return this.Ok(expectationResult);
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Something went wrong inside GetAllExpectations action: {ex.Message}");
                return this.StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetExpectationById(Guid id)
        {
            try
            {
                var expectation = this.repository.Expectation.GetExpectationById(id);
                if (expectation == null)
                {
                    this.logger.LogError($"Expectation with id: {id}, hasn't been found in db.");
                    return this.NotFound();
                }
                else
                {
                    this.logger.LogInfo($"Returned expectation with id: {id}");

                    var expectationResult = this.mapper.Map<ExpectationDto>(expectation);
                    return this.Ok(expectationResult);
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Something went wrong inside GetExpectationByIds action: {ex.Message}");
                return this.StatusCode(500, "Internal server error");
            }
        }
    }
}