using Contracts;
using Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace ORM_Fun.Controllers
{
    [Route("gf_group")]
    [ApiController]
    public class GF_GroupController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public GF_GroupController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllGF_Groups()
        {
            try
            {
                var gf_groups = _repository.GF_Group.GetAllGF_Groups();
                _logger.LogInfo($"Returned all GF Groups from database.");

                var gf_groupResult = _mapper.Map<IEnumerable<GF_GroupDTO>>(gf_groups);

                return Ok(gf_groupResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllGF_Groups action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetGF_GroupById(Guid id)
        {
            try
            {
                var gf_group = _repository.GF_Group.GetGF_GroupById(id);
                if (gf_group == null)
                {
                    _logger.LogError($"GF Group with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned GF Group with id: {id}");

                    var gf_groupResult = _mapper.Map<GF_GroupDTO>(gf_group);
                    return Ok(gf_groupResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetGF_GroupById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/dimension")]
        public IActionResult GetF_GroupWithDimensions(Guid id)
        {
            try
            {
                var gf_group = _repository.GF_Group.GetGF_GroupById(id);
                
                if (gf_group == null)
                {
                    _logger.LogError($"GF Group with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned GF Group with id: {id}");

                    var gf_groupResult = _mapper.Map<GF_GroupDTO>(gf_group);
                    return Ok(gf_groupResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetF_GroupWithDimensions action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}