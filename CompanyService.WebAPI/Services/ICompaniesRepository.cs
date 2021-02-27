using CompanyService.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyService.WebAPI.Services
{
    public interface ICompaniesRepository
    {
        public string Validate(Company company);
    }
}
