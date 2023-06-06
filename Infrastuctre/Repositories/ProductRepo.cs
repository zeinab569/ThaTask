using Core.Entities;
using Core.Interfaces;
using Infrastuctre.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastuctre.Repositories
{
    public class ProductRepo : GenericRepo<Product> ,IProductRepo
    {
     
        public ProductRepo(ShoppingContext _shoppingContext) : base(_shoppingContext) { }
           
    }
}
