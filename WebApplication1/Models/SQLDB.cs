using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

public static class SQLDB
{
    private static string connectionString = "Server=localhost;Database=sistema_logistica;Uid=root;Pwd=123456;";

    public static DataTable Consultar(string sql, List<MySqlParameter> parametros = null)
    {
        using (var conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            using (var cmd = new MySqlCommand(sql, conn))
            {
                if (parametros != null)
                    cmd.Parameters.AddRange(parametros.ToArray());

                using (var da = new MySqlDataAdapter(cmd))
                {
                    var dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
    }

    public static int Executar(string sql, List<MySqlParameter> parametros = null)
    {
        using (var conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            using (var cmd = new MySqlCommand(sql, conn))
            {
                if (parametros != null)
                    cmd.Parameters.AddRange(parametros.ToArray());
                return cmd.ExecuteNonQuery();
            }
        }
    }

    public static int Inserir(string sql, List<MySqlParameter> parametros)
    {
        return Executar(sql, parametros);
    }

    public static int Atualizar(string sql, List<MySqlParameter> parametros)
    {
        return Executar(sql, parametros);
    }

    public static int Excluir(string sql, List<MySqlParameter> parametros)
    {
        return Executar(sql, parametros);
    }
}
