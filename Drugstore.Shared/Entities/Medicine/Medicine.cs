using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Drugstore.Shared.Entities.Medicamento
{
    public class Medicine
    {
       

            public int Id { get; set; }

            [Display(Name = "Medicine")]  //{0}
            [MaxLength(100, ErrorMessage = "Cuidado el campo {0} no permite más de {1} caracteres ")]  //{1}
            [Required(ErrorMessage = "El campo {0} es obligatorio")]
            public string? Name { get; set; } = null;
        
    }
}