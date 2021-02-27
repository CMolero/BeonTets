using System;
using System.ComponentModel.DataAnnotations;

namespace CompanyService.WebAPI.Models
{
    public class Company
    {
        public string CompanyName { get; set; }

        public int NumberOfEmployees { get; set; }

        public int AverageSalary { get; set; }
    }
}