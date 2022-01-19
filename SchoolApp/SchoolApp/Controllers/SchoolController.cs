﻿using Microsoft.AspNetCore.Mvc;
using SchoolApp.Dtos.School;
using SchoolApp.Models;
using SchoolApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SchoolController : ControllerBase
    {
        private readonly SchoolService _schoolService;

        public SchoolController(SchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        [HttpGet]
        public List<School> GetAll()
        {
            return _schoolService.GetAll();
        }

        [HttpGet("{id}")]
        public School GetById(int id)
        {
            return _schoolService.GetById(id);
        }

        [HttpPost]
        public void Add([FromBody] string name)
        {
            _schoolService.Create(name);
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] string newName)
        {
            _schoolService.Update(id, newName);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _schoolService.Remove(id);
        }
    }
}
