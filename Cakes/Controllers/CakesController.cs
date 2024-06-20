using Cakes.Data;
using Cakes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace Cakes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CakesController : ControllerBase
    {
        private readonly CakeDbContext _dbcontext;
       private readonly SieveProcessor _processor;
        public CakesController(CakeDbContext dbcontext,SieveProcessor sieveProcessor) { 
        
            _dbcontext = dbcontext;
            _processor = sieveProcessor;
        }
        [HttpGet]   
        public async Task<ActionResult<IEnumerable<Cakesdata>>> GetCake([FromQuery] SieveModel model )
        {
            var cake=_dbcontext.Cakesdatas.AsQueryable();
            cake=_processor.Apply(model,cake);
            return Ok(cake);
          
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cakesdata>> GetCake(int id)
        {
            if (_dbcontext.Cakesdatas == null)
            {
                return NotFound();
            }
            var ca = await _dbcontext.Cakesdatas.FindAsync(id);
            if (ca == null)
            {
                return NotFound();
            }
            return ca;
        }
        [HttpPost]
        public async Task<ActionResult<Cakesdata>>PostCake(Cakesdata Cake)
        {
            _dbcontext.Cakesdatas.Add(Cake);
            await _dbcontext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCake),new {id=Cake.Id},Cake);
        }
      [HttpDelete("{id}")]
      public async Task<ActionResult<Cakesdata>>DeletCakes(int id)
        {
            if(_dbcontext.Cakesdatas == null)
            {
                return NotFound();
            }
            var cak=await _dbcontext.Cakesdatas.FindAsync(id);
            if (cak == null)
            {
                return NotFound();
            }
            _dbcontext.Cakesdatas.Remove(cak);
            await _dbcontext.SaveChangesAsync();
                return Ok();
        }
       
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCakes(int id, Cakesdata cake)
        {
            

            var existingCake = await _dbcontext.Cakesdatas.FindAsync(id);
            if (existingCake == null)
            {
                return NotFound("Cake not found.");
            }

            existingCake.Nameofcake = cake.Nameofcake;
            existingCake.Prince = cake.Prince;

            _dbcontext.Cakesdatas.Update(existingCake);
            await _dbcontext.SaveChangesAsync();

            return Ok(existingCake);
        }



    }
}
