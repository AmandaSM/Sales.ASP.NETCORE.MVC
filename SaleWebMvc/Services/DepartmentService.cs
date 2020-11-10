using SaleWebMvc.Data;
using SaleWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleWebMvc.Services
{
    public class DepartmentService
    {
        private readonly SaleWebMvcContext _context;//n altera valor

        public DepartmentService(SaleWebMvcContext context)
        {
            _context = context;
        }
        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x=> x.Name).ToList();
        }
    }
}
