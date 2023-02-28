using System.ComponentModel.DataAnnotations;

namespace Demo1Shared.DTOs
{
    public class CustomerDto
    {
        public string CustomerId { get; set; }

        [Display(Name = "Compañia"), Required(ErrorMessage = "La {0} es requerida")]
        public string CompanyName { get; set; }
        [Display(Name = "Nombre Contacto"), Required(ErrorMessage = "El {0} es requerido")]
        public string ContactName { get; set; }
        [Display(Name = "Cuidad"), Required(ErrorMessage = "La {0} es requerido")]
        public string City { get; set; }
        [Display(Name = "Teléfono"), Required(ErrorMessage = "El {0} es requerido")]
        public string Phone { get; set; }

        public CustomerDto() { }
    }

}
