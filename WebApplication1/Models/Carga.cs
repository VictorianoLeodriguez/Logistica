using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Carga
    {
        public int codigo { get; set; }

        public string Descricao { get; set; }

        public string Remetente { get; set; }

        public string Quantidade { get; set; }
    }
}