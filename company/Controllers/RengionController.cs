using company.Data;
using company.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RengionController : ControllerBase
    {
        private readonly CompanyDbContext _dbContext;
        public RengionController(CompanyDbContext dbContext) { 
        
            _dbContext = dbContext;
        }
        [HttpGet]
        public List<Rengion> GetAll()
        {
            return _dbContext.Rengion.ToList();
            
        }
    }
}
