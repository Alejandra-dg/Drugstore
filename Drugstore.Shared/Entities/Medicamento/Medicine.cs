using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Drugstore.Shared.Entities.Medicamento
{
    public class Medicine
    {
        public int medicine_id { get; set; }


                [Display(Name = "Nombre")]
                [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
                [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string medicine_name { get; set; } = null!;


                [DataType(DataType.MultilineText)]
                [Display(Name = "Descripción")]
                [MaxLength(500, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string Description { get; set; } = null!;


                [Column(TypeName = "decimal(18,2)")]
                [DisplayFormat(DataFormatString = "{0:C2}")]
                [Display(Name = "Precio")]
                [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal Price { get; set; }


                [DisplayFormat(DataFormatString = "{0:N2}")]
                [Display(Name = "Inventario")]
                [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public float Stock { get; set; }


       public ICollection<Category>? MedicineCategories { get; set; }


                [Display(Name = "Categorías")]
        public int MedicineCategoriesNumber => MedicineCategories == null ? 0 : MedicineCategories.Count;


        public ICollection<MedicineImage>? MedicineImages { get; set; }


                [Display(Name = "Imágenes")]
        public int MedicineImagesNumber => MedicineImages == null ? 0 : MedicineImages.Count;


             [Display(Name = "Imagen")]
        public string MainImage => MedicineImages == null ? string.Empty : MedicineImages.FirstOrDefault()!.url_image;



    }
}