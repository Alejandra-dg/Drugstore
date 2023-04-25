using Drugstore.Shared.Entities.Medicamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugstore.Shared.Entities.Medicine
{
    public class ProductMedicine
    {
        public int Id { get; set; }

        public Product Product { get; set; } = null!;

        public int ProductId { get; set; }

        public Category Medicine { get; set; } = null!;

        public int MedicineId { get; set; }
    }
}
