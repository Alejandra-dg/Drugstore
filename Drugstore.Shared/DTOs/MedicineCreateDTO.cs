using Drugstore.Shared.Entities.Medicamento;
using Drugstore.Shared.Entities.Usuario;

namespace Drugstore.Shared.DTOs
{
    public class MedicineCreateDTO : Medicine
    {
 
        public List<int> CategoryList { get; set; } = new();

        
    }
}
