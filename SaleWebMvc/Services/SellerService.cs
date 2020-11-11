using Microsoft.EntityFrameworkCore;
using SaleWebMvc.Data;
using SaleWebMvc.Models;
using SaleWebMvc.Views.Sellers.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleWebMvc.Services
{
    public class SellerService
    {
        private readonly SaleWebMvcContext _context;//n altera valor

        public SellerService(SaleWebMvcContext context)
        {
            _context = context;
        }
        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
        public void Insert(Seller obj)
        {           
            _context.Add(obj);
            _context.SaveChanges();
        }
        public  Seller FindById(int id)
        {
            return _context.Seller.Include(Obj => Obj.Department).FirstOrDefault(obj => obj.Id == id);
        }
       public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }
        public void Update(Seller obj)
        {
            if (!_context.Seller.Any(x=> x.Id == obj.Id))
            {//pegando obj e comparando com outro x id, para ver se é igual 
                throw new NotFoundException("ID NOT FOUND");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {//camada de bd -> camada de serviço
                throw new DbConcurrencyException(e.Message);
            }
           
        }
    }
}
