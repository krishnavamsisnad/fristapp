using CompanyofSnad.Data;
using CompanyofSnad.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyofSnad.Controllers.v2
{
   
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    public class EmployeDetailesController : ControllerBase
    {
        private readonly DataDbContext _dbContext;

        public EmployeDetailesController(DataDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employedetailes>>> GetEmployedetalies()
        {
            var employeeDetails = await _dbContext.Employedetailes.ToListAsync();
            return Ok(employeeDetails);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployeeDetails([FromBody] Employedetailes employeeDetails)
        {
            if (employeeDetails == null || employeeDetails.Employes == null)
            {
                return BadRequest("The employes field is required.");
            }

            _dbContext.Employedetailes.Add(employeeDetails);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployedetalies), new { id = employeeDetails.Employeid }, employeeDetails);
        }
    }
}
