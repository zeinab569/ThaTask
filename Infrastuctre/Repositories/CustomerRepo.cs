using Core.Entities;
using Core.Interfaces;
using Infrastuctre.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastuctre.Repositories
{
    public class CustomerRepo: GenericRepo<Customer>, ICustomerRepo
    {
        private readonly ShoppingContext _shoppingContext;

        public CustomerRepo(ShoppingContext shoppingContext) : base(shoppingContext) { _shoppingContext = shoppingContext; }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            var customerDetails = await _shoppingContext.Customers
                .Include(x => x.Products)
                .FirstOrDefaultAsync(x => x.Id == id);
            return customerDetails;
        }
    }

}
