using System.ComponentModel.DataAnnotations;

namespace Drugstore.Shared.Entities.Medicamento
{
    public class Category
    {
        public int category_id { get; set; }


                [Display(Name = "Categoría")]
                [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
                [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string category_name { get; set; } = null!;


        //Realiza una colección de datos conjugados de categoría y medicamento
        public ICollection<MedicineCategory>? MedicineCategories { get; set; }


        [Display(Name = "Medicamentos")]
        //Para realizar el conteo de medicamentos por cada categoría
        public int MedicineCategoriesNumber => MedicineCategories == null ? 0 : MedicineCategories.Count;
        
    }
}