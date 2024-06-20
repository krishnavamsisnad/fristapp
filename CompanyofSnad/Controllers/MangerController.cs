using CompanyofSnad.Data;
using CompanyofSnad.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyofSnad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MangerController : ControllerBase
    {
        private readonly DataDbContext _dbContext;
        public MangerController(DataDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manager>>> GetDepartement()
        {

            return await _dbContext.Managers.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<Manager>>AddManger(Manager manager)
        {
            _dbContext.Managers.Add(manager);   
            await _dbContext.SaveChangesAsync();    
            return Ok(manager);
        }
    }
}
