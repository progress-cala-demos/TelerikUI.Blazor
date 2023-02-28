using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1Shared.DTOs
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerId { get; set; }
        [Display(Name = "Compañia"), Required(ErrorMessage = "La {0} es requerida")]
        public string CompanyName { get; set; }
        [Display(Name = "Dirección"), Required(ErrorMessage = "La {0} es requerida")]
        public string ShipAddress { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }

        public OrderDto() { }
    }
}
