using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Database
{
    public class CaminhaoDB
    {
        public static bool Adicionar(Caminhao user)
        {
            string sql = @"INSERT INTO cmho (CMHO_PLA, CMHO_MDL)
                           VALUES (@CMHO_PLA, @CMHO_MDL)";
            var parametros = new List<MySqlParameter>
            {
                new MySqlParameter("CMHO_PLA", user.Placa),
                new MySqlParameter("CMHO_MDL", user.Modelo)
            };

            return SQLDB.Executar(sql, parametros) > 0;
        }

        public static bool Editar(Caminhao user, int id = -1)
        {
            string sql = @"UPDATE cmho 
                           SET CMHO_PLA = @CMHO_PLA,
                               CMHO_MDL = @CMHO_MDL
                           WHERE CMHO_AIC = @CMHO_AIC";
            var parametros = new List<MySqlParameter>
            {
                new MySqlParameter("CMHO_PLA", user.Placa),
                new MySqlParameter("CMHO_AIC", id),
                new MySqlParameter("CMHO_MDL", user.Modelo)
            };

            return SQLDB.Executar(sql, parametros) > 0;
        }

        public static bool Excluir(int codigo)
        {
            string sql = @"DELETE FROM cmho WHERE CMHO_AIC = @CMHO_AIC";
            var parametros = new List<MySqlParameter>
            {
                new MySqlParameter("CMHO_AIC", codigo)
            };

            return SQLDB.Executar(sql, parametros) > 0;
        }

        public static List<Caminhao> Lista(Caminhao user)
        {
            var cmd = @"SELECT CMHO_AIC, CMHO_PLA, CMHO_MDL
                        FROM cmho";

            DataTable dt = SQLDB.Consultar(cmd);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            var lista = new List<Caminhao>();

            foreach (DataRow r in dt.Rows)
            {
                lista.Add(new Caminhao
                {
                    Codigo = Convert.ToInt32(r["CMHO_AIC"]),
                    Placa = r["CMHO_PLA"].ToString(),
                    Modelo = r["CMHO_MDL"].ToString()
                });
            }
            return lista;
        }
    }
}