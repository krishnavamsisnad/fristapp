
using Dbapproch.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cakes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly CakeDbContext _dbcontext;
        public DeliveryController(CakeDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Delivery>>> Getalldevliery()
        {
            if (_dbcontext.Deliveries == null)
            {
                return BadRequest();
            }
            return await _dbcontext.Deliveries.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Delivery>> Getbyid(int id)
        {
            if (_dbcontext.Deliveries == null)
            {
                return BadRequest();
            }
            var de = await _dbcontext.Deliveries.FindAsync(id);
            if (de == null)
            {
                return BadRequest();
            }
            return Ok(de);
        }
        [HttpPost]
        public async Task<ActionResult<Delivery>> Adddevliery(Delivery delivery)
        {
            _dbcontext.Deliveries.Add(delivery);
            await _dbcontext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Delivery>> Updatedelivery(int id, Delivery delivery)
        {
            var upda = await _dbcontext.Deliveries.FindAsync(id);
            if (upda == null)
            {
                return NotFound();
            }
            upda.Name = delivery.Name;
            upda.Phonenumber = delivery.Phonenumber;
            _dbcontext.Deliveries.Update(upda);
            await _dbcontext.SaveChangesAsync();

            return Ok(upda);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Delivery>> Deletdevliery(int id, Delivery delivery)
        {
            var updat = await _dbcontext.Deliveries.FindAsync(id);
            if (updat == null)
            {
                return NotFound();
            }
            _dbcontext.Deliveries.Update(updat);
            await _dbcontext.SaveChangesAsync();
            return Ok(updat);
        }
    }

}

