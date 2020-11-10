
using System.Collections.Generic;

namespace SaleWebMvc.Models.ViewMoldels
{
    public class SellerFormViewModel
    {
        public Seller Seller { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
