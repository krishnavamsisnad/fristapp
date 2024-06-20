using Address.Data;
using Address.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace Address.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly PersonDbContext _dbContext;

        public AddressController(PersonDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
       
        public async Task<ActionResult<IEnumerable<Addressdata>>> GetAddress()
        {
            var addresses = await _dbContext.Addressdata.ToListAsync();
            return Ok(addresses);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Addressdata>> AddAddress(Addressdata addressdata)
        {
            _dbContext.Addressdata.Add(addressdata);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Addressdata>> Updatedelivery(int id,Addressdata addressdata)
        {
            var upda = await _dbContext.Addressdata.FindAsync(id);
            if (upda == null)
            {
                return NotFound();
            }
            upda.Address = addressdata.Address;
            upda.City= addressdata.City;
            _dbContext.Addressdata.Update(upda);
            await _dbContext.SaveChangesAsync();
            return Ok(upda);
        }
    }
}
