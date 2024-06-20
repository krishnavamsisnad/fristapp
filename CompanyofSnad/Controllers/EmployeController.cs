using CompanyofSnad.Data;
using CompanyofSnad.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyofSnad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<ActionResult<Employes>> AddEmploy(Employes employes)
        {
            _dbContext.Employes.Add(employes);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        
    }
}
