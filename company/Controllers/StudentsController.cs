using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllstudents()
        {
            string[] studentsname = new string[] { "vamsi", "sai" };
            return Ok(studentsname);
            }
    }
}
