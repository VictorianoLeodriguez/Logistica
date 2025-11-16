using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Database
{
    public class CargaDB
    {
        public static bool Adicionar(Carga carga)
        {
            string sql = @"INSERT INTO crg (CRG_DESC, CRG_REM, CRG_QNT)
                           VALUES (@CRG_DESC, @CRG_REM, @CRG_QNT)";
            var parametros = new List<MySqlParameter>
            {
                new MySqlParameter("CRG_DESC", carga.Descricao),
                new MySqlParameter("CRG_REM", carga.Remetente),
                new MySqlParameter("CRG_QNT", carga.Quantidade)
            };

            return SQLDB.Executar(sql, parametros) > 0;
        }

        public static bool Editar(Carga carga, int id = -1)
        {
            string sql = @"UPDATE crg 
                           SET CRG_DESC = @CRG_DESC,
                               CRG_REM = @CRG_REM,
                               CRG_QNT = @CRG_QNT
                           WHERE CRG_AIC = @CRG_AIC";
            var parametros = new List<MySqlParameter>
            {
                new MySqlParameter("CRG_DESC", carga.Descricao),
                new MySqlParameter("CRG_AIC", id),
                new MySqlParameter("CRG_REM", carga.Remetente),
                new MySqlParameter("CRG_QNT", carga.Quantidade)
            };

            return SQLDB.Executar(sql, parametros) > 0;
        }

        public static bool Excluir(int codigo)
        {
            string sql = @"DELETE FROM crg WHERE CRG_AIC = @CRG_AIC";
            var parametros = new List<MySqlParameter>
            {
                new MySqlParameter("CRG_AIC", codigo)
            };

            return SQLDB.Executar(sql, parametros) > 0;
        }

        public static List<Carga> Lista(Carga carga)
        {
            var cmd = @"SELECT CRG_AIC, CRG_DESC, CRG_REM, CRG_QNT
                        FROM crg";

            DataTable dt = SQLDB.Consultar(cmd);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            var lista = new List<Carga>();

            foreach (DataRow r in dt.Rows)
            {
                lista.Add(new Carga
                {
                    codigo = Convert.ToInt32(r["CRG_AIC"]),
                    Quantidade = r["CRG_QNT"].ToString(),
                    Remetente = r["CRG_REM"].ToString(),
                    Descricao = r["CRG_DESC"].ToString()
                });
            }
            return lista;
        }
    }
}