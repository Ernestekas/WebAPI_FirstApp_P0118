using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("test")]
        public School Get()
        {
            School test = new School()
            {
                Id = 1,
                Name = "Dziundzikas Bumbikas",
                Created = DateTime.Now
            };

            return test;
        }
    }
}
