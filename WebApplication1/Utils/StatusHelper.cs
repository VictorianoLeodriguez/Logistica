using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Utils
{
    public class StatusHelper
    {
        public enum StatusEntrega
        {
            Pendente = 0,
            EmRota = 1,
            Entregue = 2,
            Cancelado = 3,
            Devolvido = 4,
            AguardandoRetirada = 5,
            Retirado = 6,
        }

        public List<string> ListarStatusEntrega()
        {
            return new List<string>
            {
                "Pendente",
                "Em Rota",
                "Entregue",
                "Cancelado",
                "Devolvido",
                "Aguardando Retirada",
                "Retirado"
            };
        }
    }
}