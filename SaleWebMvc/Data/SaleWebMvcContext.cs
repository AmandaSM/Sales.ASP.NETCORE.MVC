using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SaleWebMvc.Models;

namespace SaleWebMvc.Data
{
    public class SaleWebMvcContext : DbContext
    {
        public SaleWebMvcContext(DbContextOptions<SaleWebMvcContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecords { get; set; }
    }
}
