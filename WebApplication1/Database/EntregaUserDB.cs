using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Database
{
    public class EntregaUserDB
    {
        public static List<EntregaUser> Lista()
        {
            var cmd = @"SELECT ETG_AIC, USR_AIC, ETG_DEST, ETG_SATUS, ETG_DTET, ETG_HRET
        FROM etg";

            DataTable dt = SQLDB.Consultar(cmd);

            if (dt == null || dt.Rows.Count == 0)
                return new List<EntregaUser>(); // nunca retorna null

            var lista = new List<EntregaUser>();

            foreach (DataRow r in dt.Rows)
            {
                lista.Add(new EntregaUser()
                {
                    USR_AIC = r["USR_AIC"] != DBNull.Value ? Convert.ToInt32(r["USR_AIC"]) : 0,
                    Codigo = r["ETG_AIC"] != DBNull.Value ? Convert.ToInt32(r["ETG_AIC"]) : 0,
                    Destino = r["ETG_DEST"].ToString(),
                    Status_ETG = r["ETG_SATUS"].ToString(),
                    Data_ETG = r["ETG_DTET"] != DBNull.Value ? Convert.ToDateTime(r["ETG_DTET"]) : DateTime.MinValue,
                    Hora_ETG = r["ETG_HRET"] != DBNull.Value && TimeSpan.TryParse(r["ETG_HRET"].ToString(), out var horaRg) ? horaRg : default
                });
            }

            return lista;
        }

        public static bool AtualizarStatus(EntregaUser entrega, int id = -1)
        {
            entrega.Data_ETG = DateTime.Now;
            entrega.Hora_ETG = DateTime.Now.TimeOfDay;

            string sql = @"UPDATE etg 
                  SET ETG_SATUS = @ETG_SATUS,
                      ETG_DTET = @ETG_DTET,
                      ETG_HRET = @ETG_HRET
                WHERE ETG_AIC = @ETG_AIC";
            var parametros = new List<MySqlParameter>
            {
                new MySqlParameter("@ETG_SATUS", entrega.Status_ETG),
                new MySqlParameter("@ETG_DTET", entrega.Data_ETG),
                new MySqlParameter("@ETG_HRET", entrega.Hora_ETG),
                new MySqlParameter("@ETG_AIC", id)
            };

            return SQLDB.Executar(sql, parametros) > 0;
        }
    }
}