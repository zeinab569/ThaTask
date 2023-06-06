using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Order:BaseEntity
    {
        [Required]
        public DateTime OrderDate { get; set; }
        
        public int CustomerId { get; set; }
        public Customer Customers { get; set; }

        public int ProductId { get; set; }
        public Product  Products { get; set; }
    }
}
