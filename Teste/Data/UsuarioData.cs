using Dapper;
using Model;

using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Data
{
    public static class UsuarioData
    {


        public static List<Usuario> Listar()
        {
            List<Usuario> retorno = new List<Usuario>();

            using (var dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString))
            {
                dbConn.Open();
                var strQuery = @"SELECT id, nome, telefone, email, cpf, endereco  FROM usuario";
                retorno = dbConn.Query<Usuario>(strQuery).ToList();
            }
            return retorno;
        }

        public static long Criar(Usuario model)
        {
            using (var dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString))
            {
                dbConn.Open();
                var parameters = new
                {
                    Nome = model.Nome,
                    Telefone = model.Telefone,
                    Email = model.Email,
                    Cpf = model.Cpf,
                    Endereco = model.Endereco
                };
                string strSql = $@"insert into usuario ( Nome, telefone, email, cpf, endereco) 
                                values ( @Nome,@Telefone,@Email,@Cpf,@Endereco);
                                select @@identity";
                var idRetorno = dbConn.ExecuteScalar<long>(strSql, parameters);
                return idRetorno;
            }
        }

        public static void Atualizar(Usuario model)
        {
            using (var dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString))
            {
                dbConn.Open();
                var parameters = new
                {
                    Id = model.Id,
                    Nome = model.Nome,
                    Telefone = model.Telefone,
                    Email = model.Email,
                    Cpf = model.Cpf,
                    Endereco = model.Endereco
                };
                string strSql = $@"update usuario set Nome=@Nome, telefone = @Telefone, email = @Email, cpf=@Cpf, endereco=@Endereco where id=@Id";
                dbConn.Execute(strSql, parameters);
            }
        }

        public static void Excluir(long id)
        {
            using (var dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString))
            {
                dbConn.Open();
                var parameters = new
                {
                    Id = id
                };
                string strSql = $"delete from usuario where id= @Id";
                dbConn.Execute(strSql, parameters);
            }
        }
    }
}