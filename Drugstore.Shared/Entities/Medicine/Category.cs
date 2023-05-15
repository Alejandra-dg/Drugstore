using System.ComponentModel.DataAnnotations;

namespace Drugstore.Shared.Entities.Medicamento
{
    public class Category
    {
        public int Id { get; set; }

        [Display(Name = "Categoría")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;


        public ICollection<Medicine>? Medicine { get; set; }

        [Display(Name = "Medicamentos")]
        public int MedicineCategoriesNumber => Medicine == null ? 0 : Medicine.Count;


    }
}