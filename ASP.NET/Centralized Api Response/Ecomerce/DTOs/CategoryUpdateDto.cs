using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecomerce.DTOs
{
    public class CategoryUpdateDto
    {   
        
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be atlest 2 chararcter")]
        public string? Name { get; set; }

        [StringLength(500,MinimumLength = 2, ErrorMessage = "Category Description Must be 2 to 500 charecter")]
        public string Description { get; set; } = string.Empty;
    }
}