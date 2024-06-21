using CompanyofSnad.Data;
using CompanyofSnad.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyofSnad.Controllers.v1
{
   
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class EmployeController : ControllerBase
    {
        private readonly DataDbContext _dbContext;

        public EmployeController(DataDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employes>>> GetEmploy()
        {
            var employes = await _dbContext.Employes.ToListAsync();
            return Ok(employes);
        }

        [HttpPost]
        [Route("AddEmploy")]
        public async Task<ActionResult<Employes>> AddEmploy([FromQuery] Employes employes)
        {
            _dbContext.Employes.Add(employes);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

    }
}
