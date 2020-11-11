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
        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }
        public async Task InsertAsync(Seller obj)
        {           
            _context.Add(obj);
            await _context.SaveChangesAsync();//Async pois é a unica que vai no bd
            //await avisa copilador que é async
        }
        public  async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(Obj => Obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }
       public async Task RemoveAsync (int id)
        {
            var obj = await _context.Seller.FindAsync(id);
            _context.Seller.Remove(obj);
           await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Seller obj)
        {
            if ( !await _context.Seller.AnyAsync(x=> x.Id == obj.Id))
            {//pegando obj e comparando com outro x id, para ver se é igual 
                throw new NotFoundException("ID NOT FOUND");
            }
            try
            {
                _context.Update(obj);
               await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {//camada de bd -> camada de serviço
                throw new DbConcurrencyException(e.Message);
            }
           
        }
    }
}
