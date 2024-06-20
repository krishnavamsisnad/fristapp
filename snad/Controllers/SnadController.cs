using Azure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using snad.Data;
using snad.Models;

namespace snad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnadController : ControllerBase
    {
        private readonly SnadContext _dbContext;
        public SnadController(SnadContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public Snaddata Creat(Snaddata data) {
        _dbContext.Snaddata.Add(data);  
        _dbContext.SaveChanges();

            return _dbContext.Snaddata.ToList().LastOrDefault();
        
        }
        [HttpGet]
        public List <Snaddata> GetSnaddatas()
        {
            return _dbContext.Snaddata.ToList();
        }
        [HttpGet("{id}")]
        public Snaddata GetSnaddataById(int id) {
        return _dbContext.Snaddata.Find(id);
        }
        [HttpPut("{id}")]
        public Snaddata updatesnaddata(Snaddata data, int id)
        {
            var cli = _dbContext.Snaddata.Find(id);
            if (cli != null)
            {
                cli.Id = id;
                cli.Usernmae = data.Usernmae;
                cli.Password = data.Password;
                cli.Email = data.Email;
                _dbContext.Snaddata.Update(cli);
                _dbContext.SaveChanges();
                return _dbContext.Snaddata.Find(id);
            }
            else
            {
                return null;

            }
        }
        [HttpDelete("{id}")]
        public void DeleteSnaddata(int id) {
            var de = _dbContext.Snaddata.Find(id);
            if (de != null) { 
            _dbContext.Snaddata.Remove(de);
                _dbContext.SaveChanges();
            }
        }
    }
}
