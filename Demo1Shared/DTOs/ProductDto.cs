using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1Shared.DTOs
{
    public class ProductDto
    {
        [Display(Name = "ID")]
        public int ProductId { get; set; }

        [Display(Name = "Producto"), Required(ErrorMessage = "{0} requerido")]
        public string ProductName { get; set; }

        [Display(Name = "Categoria"), RegularExpression("(^[1-9]\\d*$)", ErrorMessage = "{0} requerida")]
        public int CategoryId { get; set; }
        
        public string CategoryName { get; set; }

        [Display(Name = "Precio")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "Unidades en Stock"), Range(1, 1000, ErrorMessage = "Unidades entre {1} y {2}")]
        public short UnitsInStock { get; set; }

        [Display(Name = "Descontinuado" )]
        public bool Discontinued { get; set; }

        public ProductDto()
        {
            CategoryId = 1;
        }
    }
}
