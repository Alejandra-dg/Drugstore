using Drugstore.Shared.Entities.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugstore.Shared.Entities.Medicamento
{
    public class MedicineCategory
    {
        public int medicine_category_id { get; set; }

        public Medicine Medicine { get; set; } = null!;

        public int medicine_id { get; set; }

        public Category  Category    { get; set; } = null!;

        public int category_id { get; set; }
    }
}
