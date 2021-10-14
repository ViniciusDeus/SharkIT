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
    public class CarroData
    {
        public static List<Carro> Listar()
        {
            List<Carro> retorno = new List<Carro>();

            using (var dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ESTAPAR"].ConnectionString))
            {
                dbConn.Open();
                var strQuery = @"SELECT idCarro, marca, modelo, placa FROM Carro";
                retorno = dbConn.Query<Carro>(strQuery).ToList();
            }
            return retorno;
        }

        public static long Criar(Carro model)
        {
            using (var dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ESTAPAR"].ConnectionString))
            {
                dbConn.Open();
                var parameters = new
                {
                    marca = model.marca,
                    modelo = model.modelo,
                    placa = model.placa
                };
                string strSql = $@"insert into Carro ( marca, modelo, placa) 
                                values ( @marca,@modelo,@placa);
                                select @@identity";
                var idRetorno = dbConn.ExecuteScalar<long>(strSql, parameters);
                return idRetorno;
            }
        }

        public static void Atualizar(Carro model)
        {
            using (var dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ESTAPAR"].ConnectionString))
            {
                dbConn.Open();
                var parameters = new
                {
                    idCarro = model.idCarro,
                    marca = model.marca,
                    modelo = model.modelo,
                    placa = model.placa
                };
                string strSql = $@"update Carro 
                                      set marca=@marca, modelo = @modelo, placa = @placa
                                    where idCarro = @idCarro";
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
                string strSql = $"delete from Carro where idCarro = @Id";
                dbConn.Execute(strSql, parameters);
            }

        }
    }
}
