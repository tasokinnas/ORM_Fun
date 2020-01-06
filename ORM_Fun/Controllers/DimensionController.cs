using Contracts;
using Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace ORM_Fun.Controllers
{
    [Route("dimension")]
    [ApiController]
    public class DimensionController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public DimensionController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllDimensions()
        {
            try
            {
                var dimensions = _repository.Dimension.GetAllDimensions();
                _logger.LogInfo($"Returned all dimensions from database.");

                var dimensionResult = _mapper.Map<IEnumerable<DimensionDTO>>(dimensions);

                return Ok(dimensionResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllDimensions action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetDimensionById(Guid id)
        {
            try
            {
                var dimension = _repository.Dimension.GetDimensionById(id);
                if (dimension == null)
                {
                    _logger.LogError($"Dimension with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned dimension with id: {id}");

                    var dimensionResult = _mapper.Map<DimensionDTO>(dimension);
                    return Ok(dimensionResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetDimensionById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}