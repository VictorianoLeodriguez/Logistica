using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Login
    {
        [Required(ErrorMessage = "O campo Usuário é obrigatório.")]
        [Display(Name = "Usuário")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }
        public string Role { get; set; }

        public int USR_AIC { get; set; }
        public string USR_EML { get; set; }
    }
}