using Microsoft.EntityFrameworkCore;
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
        public  async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x=> x.Name).ToListAsync();
        }
    }
}
