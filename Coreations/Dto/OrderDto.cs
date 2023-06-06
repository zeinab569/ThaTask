using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Coreations.Dto
{
    public class OrderDto
    {
        [Required(ErrorMessage = "Please choose a product.")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please choose a customer.")]
        public int CustomerId { get; set; }

        public IEnumerable<SelectListItem> Products { get; set; }

        public IEnumerable<SelectListItem> Customers { get; set; }
    }
}
