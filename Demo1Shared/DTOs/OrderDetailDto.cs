using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1Shared.DTOs
{
    public class OrderDetailDto
    {
        public int OrderId { get; set; }
        [Required(ErrorMessage = "El producto es requerido")]
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        [Range(1, 100, ErrorMessage = "Cantidad entre {1} y {2}") ]
        public int Quantity { get; set; }
        public float Discount { get; set; }

        public OrderDetailDto() { }
    }
}
