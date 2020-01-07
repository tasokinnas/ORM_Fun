// <copyright file="FacetController.cs" company="Allata, LLC">
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

    [Route("facet")]
    [ApiController]
    public class FacetController : ControllerBase
    {
        private ILoggerManager logger;
        private IRepositoryWrapper repository;
        private IMapper mapper;

        public FacetController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            this.logger = logger;
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllFacets()
        {
            try
            {
                var facets = this.repository.Facet.GetAllFacets();
                this.logger.LogInfo($"Returned all facets from database.");

                var facetResult = this.mapper.Map<IEnumerable<FacetDto>>(facets);

                return this.Ok(facetResult);
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Something went wrong inside GetAllFacets action: {ex.Message}");
                return this.StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetFacetById(Guid id)
        {
            try
            {
                var facet = this.repository.Facet.GetFacetById(id);
                if (facet == null)
                {
                    this.logger.LogError($"Facet with id: {id}, hasn't been found in db.");
                    return this.NotFound();
                }
                else
                {
                    this.logger.LogInfo($"Returned facet with id: {id}");

                    var facetResult = this.mapper.Map<FacetDto>(facet);
                    return this.Ok(facetResult);
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Something went wrong inside GetFacetById action: {ex.Message}");
                return this.StatusCode(500, "Internal server error");
            }
        }
    }
}