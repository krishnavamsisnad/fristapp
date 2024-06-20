using Address.Data;
using Address.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
namespace Address.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartementController : ControllerBase
    {
        private readonly PersonDbContext _dbContext;
        public DepartementController(PersonDbContext dbContext) {
            _dbContext = dbContext;
        
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departement>>> GetDepartement()
        {

            return await _dbContext.Department.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<Departement>> AddEmploy(Departement departement)
        {
            _dbContext.Department.Add(departement);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Departement>> UpdateEmploy(int id, Departement departement)
        {
            var upd = await _dbContext.Department.FindAsync(id);
            if (upd == null)
            {
                return BadRequest();

            }
            upd.DepatemntName = departement.DepatemntName;
            upd.DepatmentType = departement.DepatmentType;
            _dbContext.Update(upd);
            return Ok();
        }


    }
}
