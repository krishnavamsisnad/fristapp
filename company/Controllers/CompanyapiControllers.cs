using company.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyapiControllers : ControllerBase
    {
        private readonly List<Companydata> companydatas;
        public CompanyapiControllers() {
            companydatas = new List<Companydata>
            {
                new Companydata(){Id="1",Name="Company1",Email="Company@gmail.com" },
                new Companydata(){Id="2",Name="Company2",Email="Company@gmail.com" }

            };
        }


        [HttpGet]
        public async Task<IActionResult> GetCompany()
        {
            await Task.CompletedTask;
            return Ok(companydatas);
        }
        [HttpGet("company/{id}")]
        public async Task<IActionResult> GetCompanyById(string id) { 


        var req=companydatas.Find(x => x.Id==id);
            if (req==null)
            return NotFound(req);
            return Ok(req);
        }
        [HttpPost("company")]
        public async Task<IActionResult> AddCompany(Companydata company)
        {
            companydatas.Add(company);
            await Task.CompletedTask;
            return CreatedAtAction("GetCompanyById", new {id=company.Id},company);
        }
        [HttpPut("company/{id}")]
        public async Task<IActionResult>UpdateCompany(string id, [FromBody] Companydata company)
        {
            var req=companydatas.Find(x=>x.Id==id);
            await Task.CompletedTask;
            req.Name = company.Name;
            req.Email = company.Email;
            return Ok(companydatas);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(string id)
        {
            var req=companydatas.Find(x=>x.Id == id);
            await Task.CompletedTask;
            companydatas.Remove(req);   
            return Ok(companydatas);
        }

    }
}
