using Employe.data;
using Employe.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaralyController : ControllerBase
    {
        private readonly EmployeDbContext _employeDbContext;
        public SaralyController(EmployeDbContext employeDbContext)
        {
            _employeDbContext = employeDbContext;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Saralydata>>> GetEmploy()
        {

           return await _employeDbContext.Saralydata.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<Saralydata>>AddEmploy(Saralydata saralydata)
        {
            _employeDbContext.Saralydata.Add(saralydata);
            await _employeDbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Saralydata>>UpdateEmploy(int id,Saralydata saralydata)
        {
           var upd=await _employeDbContext.Saralydata.FindAsync(id);
            if (upd == null)
            {
                return BadRequest();

            }
            upd.Employename=saralydata.Employename;
            upd.Prince=saralydata.Prince;
            _employeDbContext.Update(upd);
            return Ok();
        }
    }
}
