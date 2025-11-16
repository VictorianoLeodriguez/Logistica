using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Digests;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Helpers;
using WebApplication1.Models;

namespace WebApplication1.Database
{
    public class LoginDB
    {
        public static Login ValidarLogin(string email, string senha)
        {
            var query = @"SELECT USR_AIC, USR_EML, USR_PASS 
                          FROM usrk
                          WHERE USR_EML = @USR_EML
                          AND USR_PASS = @USR_PASS
                          ND USR_P_M = @USR_PASS";

            var parametros = new List<MySqlParameter>
            {
                new MySqlParameter("@USR_EML", email),
                new MySqlParameter("@USR_PASS", senha)
            };

            DataTable dt = SQLDB.Consultar(query, parametros);

            if(dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            var user = new Login
            {
                Senha = row["USR_PASS"].ToString(),
                Usuario = row["USR_EML"].ToString(),
            };
            return user;
        }
    }
}