using System;
using System.Threading.Tasks;
using CompanyService.WebAPI.Models;
using CompanyService.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CompanyService.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CompaniesController : ControllerBase
    {
        private readonly ICompaniesRepository _companiesRepository;
        public CompaniesController(ICompaniesRepository companiesRepository)
        {
            _companiesRepository = companiesRepository ?? throw new ArgumentNullException(nameof(companiesRepository));
        }

        [HttpPost("")]
        public async Task<IActionResult> Validate([FromBody] Company company)
        {
            string validCompany = _companiesRepository.Validate(company);
            if(validCompany == string.Empty)
            {
                return Ok();
            }
            else
            {
                return BadRequest(validCompany);
            }
        }
    }
}
