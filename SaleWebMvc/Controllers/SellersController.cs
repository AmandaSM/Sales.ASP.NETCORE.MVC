using Microsoft.AspNetCore.Mvc;
using SaleWebMvc.Models;
using SaleWebMvc.Models.ViewMoldels;
using SaleWebMvc.Services;

namespace SaleWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }
        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }
        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();//Buscando lista de derpartamento
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
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
