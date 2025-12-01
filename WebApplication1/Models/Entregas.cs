using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Utils;
using static WebApplication1.Utils.StatusHelper;

namespace WebApplication1.Models
{
    public class Entregas
    {
        public int Codigo { get; set; }
        public string Motorista { get; set; }
        public int USR_AIC { get; set; }
        public DateTime Data_ETG { get; set; }
        public TimeSpan Hora_ETG { get; set; }
        public string Destino { get; set; }
        public string Status_ETG { get; set; }
        public DateTime Data_RG { get; set; }
        public TimeSpan Hora_RG { get; set; }
        public int CRG_AIC { get; set; }

        
    }
}