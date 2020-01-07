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
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public FacetController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            this._logger = logger;
            this._repository = repository;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllFacets()
        {
            try
            {
                var facets = this._repository.Facet.GetAllFacets();
                this._logger.LogInfo($"Returned all facets from database.");

                var facetResult = this._mapper.Map<IEnumerable<FacetDto>>(facets);

                return this.Ok(facetResult);
            }
            catch (Exception ex)
            {
                this._logger.LogError($"Something went wrong inside GetAllFacets action: {ex.Message}");
                return this.StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetFacetById(Guid id)
        {
            try
            {
                var facet = this._repository.Facet.GetFacetById(id);
                if (facet == null)
                {
                    this._logger.LogError($"Facet with id: {id}, hasn't been found in db.");
                    return this.NotFound();
                }
                else
                {
                    this._logger.LogInfo($"Returned facet with id: {id}");

                    var facetResult = this._mapper.Map<FacetDto>(facet);
                    return this.Ok(facetResult);
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError($"Something went wrong inside GetFacetById action: {ex.Message}");
                return this.StatusCode(500, "Internal server error");
            }
        }
    }
}