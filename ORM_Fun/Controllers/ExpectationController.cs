using Contracts;
using Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace ORM_Fun.Controllers
{
    [Route("expectation")]
    [ApiController]
    public class ExpectationController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public ExpectationController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllExpectations()
        {
            try
            {
                var expectations = _repository.Expectation.GetAllExpectations();
                _logger.LogInfo($"Returned all expectations from database.");

                var expectationResult = _mapper.Map<IEnumerable<ExpectationDto>>(expectations);

                return Ok(expectationResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllExpectations action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{cohort_id}/{facet_id}")]
        public IActionResult GetExpectationById(Guid cohortId, Guid facetId)
        {
            try
            {
                var expectation = _repository.Expectation.GetExpectationById(cohortId, facetId);
                if (expectation == null)
                {
                    _logger.LogError($"Expectation with id: {cohortId} and {facetId}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned expectation with ids: {cohortId}, {facetId}");

                    var expectationResult = _mapper.Map<ExpectationDto>(expectation);
                    return Ok(expectationResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetExpectationByIds action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}