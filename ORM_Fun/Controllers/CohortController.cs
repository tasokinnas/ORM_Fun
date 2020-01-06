using Contracts;
using Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace ORM_Fun.Controllers
{
    [Route("cohort")]
    [ApiController]
    public class CohortController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public CohortController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllCohorts()
        {
            try
            {
                var cohorts = _repository.Cohort.GetAllCohorts();
                _logger.LogInfo($"Returned all cohorts from database.");

                var cohortResult = _mapper.Map<IEnumerable<CohortDTO>>(cohorts);

                return Ok(cohortResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllCohorts action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCohortById(Guid id)
        {
            try
            {
                var cohort = _repository.Cohort.GetCohortById(id);
                if (cohort == null)
                {
                    _logger.LogError($"Cohrt with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned cohort with id: {id}");

                    var cohortResult = _mapper.Map<CohortDTO>(cohort);
                    return Ok(cohortResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}