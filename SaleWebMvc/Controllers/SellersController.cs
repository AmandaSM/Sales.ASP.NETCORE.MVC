using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaleWebMvc.Models;
using SaleWebMvc.Services;

namespace SaleWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }
        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //indicando que é um método POST
        [ValidateAntiForgeryToken]
        //Prevenção ataque CSRF->Envio de dados maliciosos pela autenticação
        public IActionResult Create(Seller seller)
        {
         
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index)); 
            //name of->se mudar o nome do index n precisa mudar aqui

        }
    }
}
