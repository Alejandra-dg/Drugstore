//using Drugstore.Shared.Entities.Usuario;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Drugstore.Shared.Entities.Medicamento
{
    public class MedicineCategory
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public Medicine? Medicine { get; set; }

        public int MedicineId { get; set; }

        public Category Category { get; set; } = null!;

        public int CategoryId { get; set; }
    }
}
