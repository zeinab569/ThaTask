using Core.Interfaces;
using COREationsTask.Controllers;
using Infrastuctre.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Coreations.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderRepo _orderRepo;

        public OrderController(IOrderRepo orderRepo)
        {
            _orderRepo =orderRepo;
        }

        public async Task<IActionResult> TheOrderHistory()
        {

            var orders = await _orderRepo.GetAllAsync(a => a.Products, a => a.Customers);
            return View(orders);
        }
    }
}
