using SaleWebMvc.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SaleWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="{0} required")]//obrigatorio 
        [StringLength(60, MinimumLength = 3,ErrorMessage = "{0} size should bo between {2} and {1}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name ="Base Salary")]
        [Required(ErrorMessage = "{0} required")]
        [Range(100.0, 50000.0, ErrorMessage ="{0} must be from {1} to {2}")]
        [DisplayFormat(DataFormatString = "{0:F2}")]//0== ATRIBUTO
        public double BaseSalary { get; set; }

        [Display(Name = "Birth Date")]
        [Required(ErrorMessage = "{0} required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();
        public Seller()
        {

        }

        public Seller(int id, string name, string email, double baseSalary, DateTime birthDate, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BaseSalary = baseSalary;
            BirthDate = birthDate;
            Department = department;
        }
        public void AddSales(SalesRecord sales)
        {
            Sales.Add(sales);
        }public void RemoveSales(SalesRecord sales)
        {
            Sales.Remove(sales);
        }
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
