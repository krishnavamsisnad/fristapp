using Employe.data;
using Employe.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeController : ControllerBase
    {
        private readonly EmployeDbContext _dbContext;
        public EmployeController(EmployeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employ>>> GetEmploysarely()
        {
          return  await _dbContext.Employs.ToListAsync();
               
        }
        [HttpPost]
        public async Task<ActionResult<Employ>>AddSarely( [FromBody]Employ employ)
        {
           
            _dbContext.Employs.Add(employ);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
