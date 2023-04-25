using Drugstore.Shared.Entities.Medicamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugstore.Shared.Entities.Usuario
{
    public class UserRole
    {
    
        public int user_role_id { get; set; }

        public User User { get; set; } = null!;

        public int user_id { get; set; }

        public Role Role { get; set; } = null!;

        public int role_id { get; set; }
    }

}
