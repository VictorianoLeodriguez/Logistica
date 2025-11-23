using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using WebApplication1.Models;

namespace WebApplication1.Database
{
    public class CaminhaoDB
    {
        // LISTAR CAMINHÕES
        public static List<Caminhao> Listar()
        {
            string sql = @"SELECT CMHO_AIC, CMHO_PLA, CMHO_MDL FROM cmho";

            DataTable dt = SQLDB.Consultar(sql);
            if (dt.Rows.Count == 0)
                return new List<Caminhao>();

            var lista = new List<Caminhao>();

            foreach (DataRow row in dt.Rows)
            {
                lista.Add(new Caminhao
                {
                    CMHO_AIC = Convert.ToInt32(row["CMHO_AIC"]),
                    CMHO_PLA = row["CMHO_PLA"].ToString(),
                    CMHO_MDL = row["CMHO_MDL"].ToString()
                });
            }

            return lista;
        }

        // ADICIONAR
        public static bool Adicionar(Caminhao cam)
        {
            string sql = @"INSERT INTO cmho (CMHO_PLA, CMHO_MDL, USR_AIC)
                           VALUES (@CMHO_PLA, @CMHO_MDL, @USR_AIC)";

            var parametros = new List<MySqlParameter>
            {
                new MySqlParameter("@CMHO_PLA", cam.CMHO_PLA),
                new MySqlParameter("@CMHO_MDL", cam.CMHO_MDL),
                new MySqlParameter("@USR_AIC", cam.USR_AIC)
            };

            return SQLDB.Executar(sql, parametros) > 0;
        }

        // EXCLUIR
        public static bool Excluir(int id)
        {
            string sql = @"DELETE FROM cmho WHERE CMHO_AIC = @ID";

            var parametros = new List<MySqlParameter>
            {
                new MySqlParameter("@ID", id)
            };

            return SQLDB.Executar(sql, parametros) > 0;
        }
    }
}
