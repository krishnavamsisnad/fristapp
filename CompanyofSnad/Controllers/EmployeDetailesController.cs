using CompanyofSnad.Data;
using CompanyofSnad.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyofSnad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeDetailesController : ControllerBase
    {
        private readonly DataDbContext _dbContext;
        public EmployeDetailesController (DataDbContext dbContext)
        {

            _dbContext = dbContext;

        }
        [HttpGet]
        public async Task<IEnumerable<Employedetailes>> GetEmployedetalies()
        {
            return await _dbContext.Employedetailes.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<Employedetailes>> AddEmpoye(Employedetailes employedetailes)
        {
            _dbContext.Employedetailes.Add(employedetailes);
            await _dbContext.SaveChangesAsync();    
            return Ok();
        }
    }
}
