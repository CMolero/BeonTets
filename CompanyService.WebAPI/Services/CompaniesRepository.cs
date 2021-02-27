using Castle.Core.Configuration;
using CompanyService.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;

namespace CompanyService.WebAPI.Services
{
    public class CompaniesRepository : ICompaniesRepository
    {
        readonly IConfiguration _configuration;
        readonly IHttpContextAccessor _httpContextAccessor;
        public CompaniesRepository(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string Validate(Company company)
        {
            string cNamePattern = "Company Name:\\s?[A-Za-z0-9]{5,25}$";
            Regex rg = new Regex(cNamePattern);
            bool validName = rg.IsMatch(company.CompanyName);
            string message = string.Empty;
            if (!validName)
            {
                message = "CompanyName is invalid: CompanyNamemust contain a min. of 5 characters and a max. of 35";
            }
            if (company.NumberOfEmployees <= 1)
            {
                message = "NumberOfEmployees is invalid: NumberOfEmployees must be greater than 1";
            }

            if (company.AverageSalary <= 0)
            {
                message = "AverageSalary is invalid: AverageSalary must be greater than 0";
            }
            return message;
        }
    }
}
