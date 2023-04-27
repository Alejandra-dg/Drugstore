//using Drugstore.Shared.Entities.Usuario;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Drugstore.Shared.Entities.Medicamento
{
    public class MedicineCategory
    {
        public int Id { get; set; }

        [Display(Name = "Medicinas/Categories")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;

        public int MedicineId { get; set; }


        public Medicine? Medicine { get; set; }
    }
}
