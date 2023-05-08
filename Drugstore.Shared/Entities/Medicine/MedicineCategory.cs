
using Drugstore.Shared.Entities.Medicamento;

namespace Drugstore.Shared.Entities
{
    public class MedicineCategory
    {
        public int Id { get; set; }

        //public string Name { get; set; }    //temporal
  
        public Medicine Medicine { get; set; } = null!;

        public int MedicineId { get; set; }

        public Category Category { get; set; } = null!;

        public int CategoryId { get; set; }
    }
}
