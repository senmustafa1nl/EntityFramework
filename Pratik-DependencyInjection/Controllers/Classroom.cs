using Microsoft.AspNetCore.Mvc;
using Pratik_DependencyInjection.Manager;
using Pratik_DependencyInjection.Service;

namespace Pratik_DependencyInjection.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Classroom : ControllerBase
        
    {
   
        private readonly ITeacher _teacher;
        public Classroom(ITeacher  teacher)
        {
            _teacher = teacher;
            
        }
        [HttpGet]
        public IActionResult GetTeacherInfo(string firstName, string lastName)
        {
            return Ok(_teacher.GetInfo(firstName, lastName));
        }
    }
}
