﻿//using Drugstore.Shared.Entities.Medicamento;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml.Linq;

//namespace Drugstore.Shared.Entities.Usuario
//{
//    public class User
//    {

//        [Display(Name = "Documento Id")]
//        [Key]
//        public int user_id { get; set; }
        

//        [Display(Name = "Usuario")]
//        [MaxLength(50, ErrorMessage = "Cuidado el campo {0} no permite más de {1} caracteres ")]  //{1}
//        [Required(ErrorMessage = "El campo {0} es obligatorio")]
//        public string user_name { get; set; } = null;


//        [Display(Name = "Correo electrónico")]  //{0}
//        [MaxLength(100, ErrorMessage = "Cuidado el campo {0} no permite más de {1} caracteres ")]  //{1}
//        [Required(ErrorMessage = "El campo {0} es obligatorio")]
//        public string email { get; set; } = null;


//        public ICollection<UserRole>? UserRoles { get; set; }

//        [Display(Name = "Roles")]
//        public int UserRolesNumber => UserRoles == null ? 0 : UserRoles.Count;

//    }
//}
