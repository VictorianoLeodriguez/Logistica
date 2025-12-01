using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class EntregaUser
    {
        public int Codigo { get; set; }
        public int USR_AIC { get; set; }
        public DateTime Data_ETG { get; set; }
        public TimeSpan Hora_ETG { get; set; }
        public string Destino { get; set; }
        public string Status_ETG { get; set; }

    }
}