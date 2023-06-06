using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using COREationsTask.Dto;
using Infrastuctre.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace COREationsTask.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepo _customerRepo;
        

        public CustomerController(ICustomerRepo  customerRepo)
        {
            _customerRepo = customerRepo;    
        }


        public async Task<IActionResult> Index()
        {
            var customers = await _customerRepo.GetAllAsync(x =>x.Products);
            return View(customers);
        }

        public async Task<IActionResult> Details(int id)
        {
            Customer customerDetails = await _customerRepo.GetCustomerByIdAsync(id);
            if (customerDetails == null)
            {
                return View("NotFound");
            }
            return View(customerDetails);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Customer customerDetails = await _customerRepo.GetByIDAsync(id);
            if (customerDetails == null) return View("NotFound");

            return View(customerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Customer customer)
        {
            Customer customerDetails = await _customerRepo.GetByIDAsync(id);
            if (customerDetails == null) return View("NotFound");
            if (ModelState.IsValid)
            {
                await _customerRepo.UpdateAsync(id, customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Customer customerDetails = await _customerRepo.GetByIDAsync(id);
            if (customerDetails == null) return View("NotFound");

            return View(customerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            Customer customerDetails = await _customerRepo.GetByIDAsync(id);
            if (customerDetails == null) return View("NotFound");
            await _customerRepo.DeleteAsync(id);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Create(int id) => View();

       
        [HttpPost]
        public async Task<IActionResult> Create(int id, Customer customer)
        {
            if (ModelState.IsValid)
            {
                await _customerRepo.AddAsync(customer);
                return RedirectToAction("Index");
            }
           
            return View(customer);
        }


        public async Task<IActionResult> Filter(string searchString)
        {
            var allCustomers = await _customerRepo.GetAllAsync(m => m.Products);
            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredCustomer = allCustomers.Where(n => n.FullName.ToUpper().Contains(searchString.ToUpper()) || n.FullName.Contains(searchString.ToUpper())).ToList();
                return View("Index", filteredCustomer);
            }

            return View("Index", allCustomers);
        }
    }
}
