using Address.Data;
using Address.Model;
using Address.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;



namespace Address.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonDbContext _dbContext;
        private readonly MyClass _myClass;
        public PersonController(PersonDbContext dbContext,MyClass myClass)
        {
            _dbContext = dbContext;
            _myClass = myClass;
        }

        [HttpPost]
        public async Task<ActionResult<Persondata>> PostPerson(Persondata persondata)
        {
            _dbContext.Persondata.Add(persondata);
            await _dbContext.SaveChangesAsync();
            string jsonString = _myClass.SerializeObject(persondata);
             CreatedAtAction(nameof(GetPerson), new { id = persondata.PersonId }, persondata);
            return Ok(jsonString);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Persondata>> GetPerson(int id)
        {
            var persondata = await _dbContext.Persondata
                .Include(p => p.Address)
                .FirstOrDefaultAsync(p => p.PersonId == id);

            if (persondata == null)
            {
                return NotFound();
            }

            return persondata;
        }
    }
}
