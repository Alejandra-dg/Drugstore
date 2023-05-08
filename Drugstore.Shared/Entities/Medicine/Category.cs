using System.ComponentModel.DataAnnotations;

namespace Drugstore.Shared.Entities.Medicamento
{
    public class Category
    {
        public object? MedicinesCategories;

        public int Id { get; set; }


                [Display(Name = "Categoría")]
                [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
                [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string? Name { get; set; } = null!;


        //Realiza una colección de datos conjugados de categoría y medicamento
        public ICollection<Medicine>? Medicines { get; set; }


        [Display(Name = "Medicamentos")]
        //Para realizar el conteo de medicamentos por cada categoría
        public int MedicinesNumber => Medicines == null ? 0 : Medicines.Count;

       
    }
}