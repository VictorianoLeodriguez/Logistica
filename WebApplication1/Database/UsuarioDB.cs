using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Database
{
    public class UsuarioDB
    {
        public static bool Adicionar(Usuario user)
        {
            string sql = @"INSERT INTO usrk (USR_NM, USR_CPF, USR_PASS, USR_EML)
                           VALUES (@USR_NM, @USR_CPF, @USR_PASS, @USR_EML)";
            var parametros = new List<MySqlParameter>
            {
                new MySqlParameter("USR_NM", user.Nome),
                new MySqlParameter("USR_CPF", user.CPF),
                new MySqlParameter("USR_PASS", user.senha),
                new MySqlParameter("USR_EML", user.Email)
            };

            return SQLDB.Executar(sql, parametros) > 0;
        }

        public static bool Editar(Usuario user, int id = -1)
        {
            string sql = @"UPDATE usrk 
                           SET USR_NM = @USR_NM,
                               USR_CPF = @USR_CPF,
                                    USR_PASS = @USR_PASS,
                                 USR_EML = @USR_EML
                           WHERE USR_AIC = @USR_AIC";
            var parametros = new List<MySqlParameter>
            {
                new MySqlParameter("USR_AIC", id),
                new MySqlParameter("USR_NM", user.Nome),
                new MySqlParameter("USR_CPF", user.CPF),
                new MySqlParameter("USR_PASS", user.senha),
                new MySqlParameter("USR_EML", user.Email)
            };

            return SQLDB.Executar(sql, parametros) > 0;
        }

        public static bool Excluir(int codigo)
        {
            string sql = @"DELETE FROM usrk WHERE USR_AIC = @USR_AIC";
            var parametros = new List<MySqlParameter>
            {
                new MySqlParameter("USR_AIC", codigo)
            };

            return SQLDB.Executar(sql, parametros) > 0;
        }

        public static List<Usuario> Lista(Usuario user)
        {
            var cmd = @"SELECT USR_AIC, USR_NM, USR_CPF
                        FROM usrk";

            DataTable dt = SQLDB.Consultar(cmd);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            var lista = new List<Usuario>();

            foreach (DataRow r in dt.Rows)
            {
                lista.Add(new Usuario
                {
                    Codigo = Convert.ToInt32(r["USR_AIC"]),
                    Nome = r["USR_NM"].ToString(),
                    CPF = r["USR_CPF"].ToString()
                });
            }
            return lista;
        }
    }
}