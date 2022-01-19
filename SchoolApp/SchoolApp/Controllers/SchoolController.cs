using Microsoft.AspNetCore.Mvc;
using SchoolApp.Dtos;
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
        public List<SchoolDto> GetAll()
        {
            return _schoolService.GetAll();
        }

        [HttpGet("{id}")]
        public SchoolDto GetById(int id)
        {
            return _schoolService.GetById(id);
        }

        [HttpPost]
        public void Add(SchoolDto schoolDto)
        {
            TryValidateModel(schoolDto);

            if (!ModelState.IsValid)
            {
                RedirectToAction(nameof(Error));
            }

            _schoolService.Create(schoolDto.SchoolName);
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

        [HttpGet]
        public void Error()
        {
            throw new System.Web.Http.HttpResponseException(System.Net.HttpStatusCode.NotAcceptable);
        }
    }
}
