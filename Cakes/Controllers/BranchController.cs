using Cakes.Data;
using Cakes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Sieve.Models;
using Sieve.Services;

namespace Cakes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly CakeDbContext _dbcontext;
        private readonly SieveProcessor _processor;
        public BranchController(CakeDbContext dbcontext,SieveProcessor sieveProcessor)
        {
            _dbcontext = dbcontext;
            _processor = sieveProcessor;        
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Branchdata>>> GetBranch([FromQuery] SieveModel model)
        {
            if (_dbcontext.Branchdatas == null)
            {

            return NotFound(); }
            var branch = _dbcontext.Branchdatas.AsQueryable();
            branch=_processor.Apply(model,branch);
            return Ok(branch);


        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Branchdata>> GetById(int id)
        {
            if(_dbcontext.Branchdatas == null)
            {
                return NotFound();
            }
          var bra=await _dbcontext.Branchdatas.FindAsync(id);
            if (bra == null)
            {
                return NotFound();
            }
            return bra;
              

        }
        [HttpPost]
        public async Task<ActionResult<Branchdata>> AddBranch(Branchdata branchdata)
        {
            _dbcontext.Branchdatas.Add(branchdata); 
            await _dbcontext.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Branchdata>> DeletBranch(int id)
        {
            if (_dbcontext.Branchdatas == null)
            {
                return NotFound();
            }

            var brand = await _dbcontext.Branchdatas.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }
            _dbcontext.Branchdatas.Remove(brand);
            await _dbcontext.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Branchdata>> UpdateBranch(int id, Branchdata branchdata)
        {
            
            var existingBranch = await _dbcontext.Branchdatas.FindAsync(id);
            if (existingBranch == null)
            {
                return NotFound("Branch not found.");
            }

            
            existingBranch.Name = branchdata.Name;
            existingBranch.Location = branchdata.Location;
            existingBranch.Review = branchdata.Review;
        

            _dbcontext.Branchdatas.Update(existingBranch);
            await _dbcontext.SaveChangesAsync();

            return Ok(existingBranch); 
        }

    }
}
