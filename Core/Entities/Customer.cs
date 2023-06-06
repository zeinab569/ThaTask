using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Customer:BaseEntity
    {

        [Required(ErrorMessage ="please Enter You Name")]
        [StringLength(100, MinimumLength =2, ErrorMessage = "Full Name must be between 2,100 characters")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Mobile Number is required"),RegularExpression(@"^01[0125][0-9]{8}$", ErrorMessage = "Invalid phone number")]
        
        public string Mobile { get; set; }

        [StringLength(250, ErrorMessage = "Address  cannot exceed 250 characters")]
        public string Address { get; set; }
        
        public List<Product> Products { get; set; }
    }
}
