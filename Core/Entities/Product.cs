using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Product:BaseEntity
    {
        [Required(ErrorMessage = "please Enter You ProductName")]
        [StringLength(100, ErrorMessage = "Product name  dont exceed 100 characters")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "please Enter the Price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        
    }
}
