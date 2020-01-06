using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace ORM_Fun.Controllers
{
    [Route("gfgroup")]
    [ApiController]
    public class GfGroupController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public GfGroupController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllGfGroups()
        {
            try
            {
                var gfGroups = _repository.GfGroup.GetAllGfGroups();
                _logger.LogInfo($"Returned all GF Groups from database.");

                var gfGroupResult = _mapper.Map<IEnumerable<GfGroupDto>>(gfGroups);

                return Ok(gfGroupResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllGfGroups action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "GfGroupById")]
        public IActionResult GetGfGroupById(Guid id)
        {
            try
            {
                var gfGroup = _repository.GfGroup.GetGfGroupById(id);
                if (gfGroup == null)
                {
                    _logger.LogError($"GF Group with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned GF Group with id: {id}");

                    var gfGroupResult = _mapper.Map<GfGroupDto>(gfGroup);
                    return Ok(gfGroupResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetGF_GroupById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/dimension")]
        public IActionResult GetGfGroupWithDimensions(Guid id)
        {
            try
            {
                var gfGroup = _repository.GfGroup.GetGfGroupWithDimensions(id);
                
                if (gfGroup == null)
                {
                    _logger.LogError($"GF Group with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned GF Group with id: {id}");

                    var gfGroupResult = _mapper.Map<GfGroupDto>(gfGroup);
                    return Ok(gfGroupResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetGfGroupWithDimensions action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateGfGroup([FromBody]GfGroupCreateDto gfGroup)
        {
            try
            {
                if (gfGroup == null)
                {
                    _logger.LogError("Owner object sent from client is null.");
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid owner object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var gfGroupEntity = _mapper.Map<GfGroup>(gfGroup);

                _repository.GfGroup.CreateGfGroup(gfGroupEntity);
                _repository.Save();

                var createdGfGroup = _mapper.Map<GfGroupDto>(gfGroupEntity);

                return CreatedAtRoute("GfGroupById", new { id = createdGfGroup.Id }, createdGfGroup);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateGfGroup action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}