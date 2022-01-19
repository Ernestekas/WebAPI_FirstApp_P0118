using Microsoft.AspNetCore.Mvc;
using SchoolApp.Dtos;
using SchoolApp.Models;
using SchoolApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        public List<SchoolDto> GetAll()
        {
            return _schoolService.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                SchoolDto schoolDto = _schoolService.GetById(id);
                return Ok(schoolDto);
            }
            catch (Exception ex)
            {
                ErrorModel errorModel = new ErrorModel()
                {
                    Message = "Selection Failed",
                    Errors = ex.Message
                };
                return NotFound(errorModel);
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] string name)
        {
            TryValidateModel(new School() { Name = name });
            if (!ModelState.IsValid)
            {
                ErrorModel errorModel = new ErrorModel()
                {
                    Message = "Validation Failed",
                    Errors = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
                };

                return BadRequest(errorModel);
            }

            int schoolId = _schoolService.Create(name);

            return Created($"~/School/{schoolId}", _schoolService.GetById(schoolId));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] string newName)
        {
            TryValidateModel(new School() { Name = newName });
            if (!ModelState.IsValid)
            {
                ErrorModel errorModel = new ErrorModel()
                {
                    Message = "Validation Failed",
                    Errors = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
                };

                return BadRequest(errorModel);
            }

            try
            {
                _schoolService.Update(id, newName);
                return Ok("School Data Updated");
            }
            catch (Exception ex)
            {
                ErrorModel errorModel = new ErrorModel()
                {
                    Message = "Update Failed",
                    Errors = ex.Message
                };

                return BadRequest(errorModel);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            try
            {
                _schoolService.Remove(id);
                return Ok("School Removed");
            }
            catch (Exception ex)
            {
                ErrorModel errorModel = new ErrorModel()
                {
                    Message = "Deletion Failed",
                    Errors = ex.Message
                };

                return BadRequest(errorModel);
            }
        }
    }
}
