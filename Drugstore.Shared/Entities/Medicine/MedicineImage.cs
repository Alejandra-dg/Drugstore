using System.ComponentModel.DataAnnotations;


namespace Drugstore.Shared.Entities.Medicamento
{
    public class MedicineImage
    {
        public int Id { get; set; }

        public Medicine Medicine { get; set; } = null!;

        public int MedicineId { get; set; }

        [Display(Name = "Imagen")]
        public string Image { get; set; } = null!;
    }
}
