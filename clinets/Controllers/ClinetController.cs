using clinets.Data;
using clinets.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Identity.Client;

namespace clinets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinetController : ControllerBase
    {
        private readonly ClinetDBContext dbContext;


        public ClinetController(ClinetDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpPost]
        public Clinetsdata CreateCli(Clinetsdata Clinet)
        {
            dbContext.Clinetsdata.Add(Clinet);
            dbContext.SaveChanges();
            return dbContext.Clinetsdata.ToList().LastOrDefault();
        }

        [HttpGet]
        public List<Clinetsdata> GetClinetsdatas()
        {
            return dbContext.Clinetsdata.ToList();
        }
   
        [HttpGet("{id}")]
        public Clinetsdata GetClinetsdatabyID(int id) {
            return dbContext.Clinetsdata.Find(id);
        }
        [HttpPut("{id}")]
        public Clinetsdata Updataclinet(Clinetsdata Clinet, int id) {
            var cli = dbContext.Clinetsdata.Find(id);
            if (cli != null)
            {
                cli.Id = id;
                cli.Name = Clinet.Name;
                cli.Email = Clinet.Email;
                dbContext.Clinetsdata.Update(cli);
                dbContext.SaveChanges(true);
                return dbContext.Clinetsdata.Find(id);
            }
            else {
                return null;
            }


        }
        [HttpDelete("{id}")]
        public void DeleteClinetsdata(int id) {
            var cli = dbContext.Clinetsdata.Find(id);
            if (cli != null) {
            dbContext.Clinetsdata.Remove(cli);
                dbContext.SaveChanges();
            
            }
           
        
        } 

    }
}
