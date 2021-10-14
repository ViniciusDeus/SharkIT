using Dapper;
using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ManobristaData
    {
        public static List<Manobrista> Listar()
        {
            List<Manobrista> retorno = new List<Manobrista>();

            using (var dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ESTAPAR"].ConnectionString))
            {
                dbConn.Open();
                var strQuery = @"SELECT idManobrista, nome, cpf, dtNascimento FROM Manobrista";
                retorno = dbConn.Query<Manobrista>(strQuery).ToList();
            }
            return retorno;
        }

        public static long Criar(Manobrista model)
        {
            using (var dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ESTAPAR"].ConnectionString))
            {
                dbConn.Open();
                var parameters = new
                {
                    nome = model.nome,
                    cpf = model.cpf,
                    dtNascimento = model.dtNascimento
                };
                string strSql = $@"insert into Manobrista ( nome, cpf, dtNascimento ) 
                                values ( @nome, @cpf, @dtNascimento);
                                select @@identity";
                var idRetorno = dbConn.ExecuteScalar<long>(strSql, parameters);
                return idRetorno;
            }
        }

        public static void Atualizar(Manobrista model)
        {
            using (var dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ESTAPAR"].ConnectionString))
            {
                dbConn.Open();
                var parameters = new
                {
                    idManobrista = model.idManobrista,
                    nome = model.nome,
                    cpf = model.cpf,
                    dtNascimento = model.dtNascimento
                };
                string strSql = $@"update Manobrista 
                                      set nome=@nome, cpf = @cpf, dtNascimento = @dtNascimento
                                    where idManobrista = @idManobrista";
                dbConn.Execute(strSql, parameters);
            }
        }

        public static void Excluir(long id)
        {
            using (var dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ESTAPAR"].ConnectionString))
            {
                dbConn.Open();
                var parameters = new
                {
                    Id = id
                };
                string strSql = $"delete from Manobrista where idManobrista = @Id";
                dbConn.Execute(strSql, parameters);
            }

        }
    }
}
