using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaleWebMvc.Models;

namespace SaleWebMvc.Data
{
    public class SeedingService
    {
        private SaleWebMvcContext _context;
        public SeedingService(SaleWebMvcContext context)
        {
            _context = context;
        }
        public void Seed()
        {
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecords.Any())
            {
                return;//DB já foi copulado/preenchido
            }
            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Electonics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");

            Seller s1 = new Seller(1, "Sara Silva", "sara@sara.com",  1000.0, new DateTime(1998, 4, 21) , d1);
            Seller s2 = new Seller(2, "Rafa", "rafa@rafa.com", 2000.0, new DateTime(1980, 4, 21), d2);
            Seller s3 = new Seller(3, "Sasuke ", "sasuke@sasuke.com", 4000.0, new DateTime(1998, 4, 21), d3);
            Seller s4 = new Seller(4, "Naruto ", "Naruto@Konoha.com", 4000.0, new DateTime(1998, 4, 21), d4);

            SalesRecord r1 = new SalesRecord(1, new DateTime(2018, 09, 25), 11000.0, Models.Enums.SaleStatus.Billed, s1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2019, 01, 8), 12000.0, Models.Enums.SaleStatus.Billed, s1);
            SalesRecord r3 = new SalesRecord(3, new DateTime(2018, 09, 25), 11000.0, Models.Enums.SaleStatus.Billed, s1);
            SalesRecord r4 = new SalesRecord(4, new DateTime(2019, 01, 8), 12000.0, Models.Enums.SaleStatus.Billed, s1);

            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4);
            _context.SalesRecords.AddRange(r1, r2, r3, r4);
            _context.SaveChanges();
        }
    }
}
