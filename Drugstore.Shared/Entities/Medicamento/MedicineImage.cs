using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Drugstore.Shared.Entities.Medicamento
{
    public class MedicineImage
    {
        public int medicine_image_id { get; set; }

        public Medicine Medicine { get; set; } = null!;
        //Llave foránea de Medicine
        public int medicine_id{ get; set; }


            [Display(Name = "Imagen")]
        public string url_image { get; set; } = null!;

    }
}
