using Dbapproch.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Sieve.Models;
using Sieve.Services;

namespace Dbapproch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CakesController : ControllerBase

    {
        private readonly CakeDbContext _dbcontext;
        private readonly  SieveProcessor _processor;
        public CakesController(CakeDbContext dbcontext, SieveProcessor processor)
        {
            _dbcontext = dbcontext;
           _processor = processor;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cakesdata>>> GetCake([FromQuery] SieveModel model)   
        {
            var products = _dbcontext.Cakesdatas.AsQueryable();
            products =_processor.Apply(model, products);

            return Ok(products);

        }
        [HttpPost]
        public async Task<ActionResult<Cakesdata>> AddCakes(Cakesdata cakesdata)
        {
            
            _dbcontext.Cakesdatas.Add(cakesdata);
            await _dbcontext.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Cakesdata>> Updatecakes(int id, Cakesdata Cake)
        {
            var exitingcake = await _dbcontext.Cakesdatas.FindAsync(id);
            if (exitingcake == null)
            {
                return BadRequest();
            }
            exitingcake.Nameofcake = Cake.Nameofcake;
            exitingcake.Prince = Cake.Prince;
            _dbcontext.Cakesdatas.Update(Cake);
            await _dbcontext.SaveChangesAsync();
            return Ok();


        }
        [HttpDelete("{id}")]
        public async Task <ActionResult<Cakesdata>>DeletCakes(int id)
        {
            var dele=await _dbcontext.Cakesdatas.FindAsync(id);
            if(dele == null)
            {
                return BadRequest();

            }
            _dbcontext.Cakesdatas.Remove(dele);
            await _dbcontext.SaveChangesAsync();
            return Ok();
        }
    }
}
