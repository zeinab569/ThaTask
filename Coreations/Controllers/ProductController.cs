using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastuctre.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace COREationsTask.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductRepo _productRepo;
        
        public ProductController(IProductRepo productRepo)
        {
            _productRepo= productRepo;
        }


        public async Task<IActionResult> Index()
        {
            IReadOnlyList<Product> values = await _productRepo.GetListAsync();
            return View(values);
        }

        public async Task<IActionResult> Details(int id)
        {
            Product ProductDetails = await _productRepo.GetByIDAsync(id);
            if (ProductDetails == null)
            {
                return View("NotFound");
            }
            return View(ProductDetails);
        }

        [HttpGet]
        
        public async Task<IActionResult> Edit(int id)
        {
            Product productDetails = await _productRepo.GetByIDAsync(id);
            if (productDetails == null) return View("NotFound");

            return View(productDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            Product producerDetails = await _productRepo.GetByIDAsync(id);
            if (producerDetails == null) return View("NotFound");
            if (ModelState.IsValid)
            {
                await _productRepo.UpdateAsync(id, product);
                return RedirectToAction("Index");
            }
            return View(product);
        }


        [HttpGet]
        
        public async Task<IActionResult> Delete(int id)
        {
            Product productDetails = await _productRepo.GetByIDAsync(id);
            if (productDetails == null) return View("NotFound");

            return View(productDetails);
        }

        [HttpPost, ActionName("Delete")]
        
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            Product productDetails = await _productRepo.GetByIDAsync(id);
            if (productDetails == null) return View("NotFound");
            await _productRepo.DeleteAsync(id);
            return RedirectToAction("Index");
        }


        [HttpGet]
        
        public IActionResult Create(int id) => View();


        [HttpPost]
        
        public async Task<IActionResult> Create(int id, Product producer)
        {
            if (ModelState.IsValid)
            {
                await _productRepo.AddAsync(producer);
                return RedirectToAction("Index");
            }
            return View(producer);
        }

    }
}
