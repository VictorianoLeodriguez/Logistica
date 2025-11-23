using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Caminhao
    {
        public int CMHO_AIC { get; set; }      // Código do caminhão

        [Required]
        public string CMHO_PLA { get; set; }   // Placa

        [Required]
        public string CMHO_MDL { get; set; }   // Modelo

        public int USR_AIC { get; set; }
    }
}