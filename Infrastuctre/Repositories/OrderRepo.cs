using Core.Entities;
using Core.Interfaces;
using Infrastuctre.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastuctre.Repositories
{
    public class OrderRepo: GenericRepo<Order>, IOrderRepo
    {
        public OrderRepo(ShoppingContext _shoppingContext) : base(_shoppingContext) { }
    }
}
