using Contracts;
using Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace ORM_Fun.Controllers
{
    [Route("facet")]
    [ApiController]
    public class FacetController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public FacetController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllFacets()
        {
            try
            {
                var facets = _repository.Facet.GetAllFacets();
                _logger.LogInfo($"Returned all facets from database.");

                var facetResult = _mapper.Map<IEnumerable<FacetDTO>>(facets);

                return Ok(facetResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllFacets action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetFacetById(Guid id)
        {
            try
            {
                var facet = _repository.Facet.GetFacetById(id);
                if (facet == null)
                {
                    _logger.LogError($"Facet with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned facet with id: {id}");

                    var facetResult = _mapper.Map<FacetDTO>(facet);
                    return Ok(facetResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetFacetById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}