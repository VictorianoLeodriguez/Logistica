using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;
using WebApplication1.Models;

namespace WebApplication1.Database
{
    public class EntregaDB
    {
        public static bool Adicionar(Entregas entrega)
        {
            string sql = @"INSERT INTO etg (USR_AIC, ETG_DEST, ETG_SATUS, CRG_AIC)
                           VALUES (@USR_AIC, @ETG_DEST, @ETG_SATUS, @CRG_AIC)";
            var parametros = new List<MySqlParameter>
            {
                new MySqlParameter("@USR_AIC", entrega.USR_AIC),
                new MySqlParameter("@ETG_DEST", entrega.Destino),
                new MySqlParameter("@ETG_SATUS", entrega.Status_ETG),
                new MySqlParameter("@CRG_AIC", entrega.CRG_AIC)

            };

            return SQLDB.Executar(sql, parametros) > 0;
        }

        public static bool Editar(Entregas entrega, int id = -1)
        {
            string sql = @"UPDATE etg 
                             SET USR_AIC = @USR_AIC,
                                 ETG_DEST = @ETG_DEST,
                                 CRG_AIC = @CRG_AIC
                           WHERE ETG_AIC = @ETG_AIC";
            var parametros = new List<MySqlParameter>
            {
                new MySqlParameter("@USR_AIC", entrega.USR_AIC),
                new MySqlParameter("@ETG_DEST", entrega.Destino),
                new MySqlParameter("@CRG_AIC", entrega.CRG_AIC),
                new MySqlParameter("@ETG_AIC", id)
            };

            return SQLDB.Executar(sql, parametros) > 0;
        }

        public static bool Excluir(int codigo)
        {
            string sql = @"DELETE FROM etg WHERE ETG_AIC = @ETG_AIC";
            var parametros = new List<MySqlParameter>
            {
                new MySqlParameter("ETG_AIC", codigo)
            };

            return SQLDB.Executar(sql, parametros) > 0;
        }


        public static List<Entregas> Lista()
        {
            var cmd = @"SELECT ETG_AIC, USR_AIC, ETG_DEST, ETG_SATUS, ETG_DTRGS, ETG_HRRGS, CRG_AIC
        FROM etg";

            DataTable dt = SQLDB.Consultar(cmd);

            if (dt == null || dt.Rows.Count == 0)
                return new List<Entregas>(); 

            var lista = new List<Entregas>();

            foreach (DataRow r in dt.Rows)
            {
                lista.Add(new Entregas
                {
                    Codigo = Convert.ToInt32(r["ETG_AIC"]),
                    Motorista = r["USR_AIC"].ToString(),
                    Destino = r["ETG_DEST"].ToString(),
                    Status_ETG = r["ETG_SATUS"].ToString(),
                    Data_RG = Convert.ToDateTime(r["ETG_DTRGS"]),
                    Hora_RG = TimeSpan.TryParse(r["ETG_HRRGS"].ToString(), out var horaRg) ? horaRg : default,
                    CRG_AIC = Convert.ToInt32(r["CRG_AIC"])
                });
            }

            return lista;
        }
    }
}