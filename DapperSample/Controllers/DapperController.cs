// <copyright file="RepositoryBase.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DapperSample.Controllers
{
    using System;
    using System.Collections.Generic;

    using DapperSample.Contracts;
    using DapperSample.Entities;
    using DapperSample.Repository;
    using Microsoft.AspNetCore.Mvc;

    [Route("book")]
    [ApiController]
    public class DapperController : ControllerBase
    {
        IRepository<Cohort> cohortRepository = null;

        public DapperController()
        {
            cohortRepository = new Repository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            IList<Cohort> cohorts = cohortRepository.GetAll();

            return Ok(cohorts);
        }
    }
}
