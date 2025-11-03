using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Utils
{
    public class Utils
    {
        #region Propriedades

        public enum StatusEntrega
        {
            Pedente = 0,
            EmRota = 1,
            Entregue = 2,
            Cancelado = 3,
            Devolvido = 4,
            AguardandoRetirada = 5,
            Retirado = 6,
        }

        #endregion Propriedades

        #region Metodos

        public List<CodigoNome> ListarStatusEntrega()
        {
            List<CodigoNome> lista = new List<CodigoNome>()
            {
                new CodigoNome { Codigo = 0, Nome = "Pendente" },
                new CodigoNome { Codigo = 1, Nome = "Em Rota" },
                new CodigoNome { Codigo = 2, Nome = "Entregue" },
                new CodigoNome { Codigo = 4, Nome = "Devolvido" },
                new CodigoNome { Codigo = 5, Nome = "Aguardando Retirada" },
                new CodigoNome { Codigo = 6, Nome = "Retirado" },
            };

            return lista;
        }


        #endregion Metodos
    }
}