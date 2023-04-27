using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Drugstore.Shared.Entities.Medicamento
{
    public class Medicine
    {
        public int Id { get; set; }

        [Display(Name = "Medicamentos")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;


        public ICollection<MedicineCategory>? MedicinesCategories{ get; set; }



        public int CategoryId { get; set; }

        public Category? Category { get; set; }

      

        [Display(Name = "Categorias/Medicinas")]
        public int MedicinesCategoriesNumber => MedicinesCategories == null ? 0 : MedicinesCategories.Count;

    }
}