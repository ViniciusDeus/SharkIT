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
    public class EstacionamentoData
    {

        public static List<Estacionamento> Listar()
        {
            List<Estacionamento> retorno = new List<Estacionamento>();

            using (var dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ESTAPAR"].ConnectionString))
            {
                dbConn.Open();
                var strQuery = @"select e.idEstacionamento,
 	                                    e.dtEntrada,
	                                    e.idManobristaEntrada,
	                                    entr.nome as NomeManobristaEntrada,		
	                                    e.idManobristaSaida,
	                                    sai.nome as NomeManobristaSaida,
	                                    c.idCarro,
	                                    c.modelo,
	                                    c.placa,
	                                    c.marca
                                   FROM Estacionamento e
                              left join Carro AS c ON e.idCarro = e.idCarro
                              left join Manobrista AS entr ON e.idManobristaEntrada = entr.idManobrista
                              left join Manobrista AS sai ON e.idManobristaEntrada = sai.idManobrista";
                retorno = dbConn.Query<Estacionamento>(strQuery).ToList();
            }
            return retorno;
        }

        public static long Criar(Estacionamento model)
        {
            using (var dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ESTAPAR"].ConnectionString))
            {
                dbConn.Open();
                var parameters = new
                {
                    dtEntrada = model.dtEntrada,
                    dtSaida = model.dtSaida,
                    idManobristraEntrada = model.manobristaEntrada.idManobrista,
                    idManobristaSaida = model.manobristaSaida.idManobrista,
                    idCarro = model.carro.idCarro
                };
                string strSql = $@"insert into Estacionamento ( dtEntrada, dtSaida, idManobristraEntrada, idManobristaSaida, idCarro ) 
                                values ( @dtEntrada,@dtSaida,@idManobristraEntrada, @idManobristaSaida, @idCarro);
                                select @@identity";
                var idRetorno = dbConn.ExecuteScalar<long>(strSql, parameters);
                return idRetorno;
            }
        }

        public static void Atualizar(Estacionamento model)
        {
            using (var dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ESTAPAR"].ConnectionString))
            {
                dbConn.Open();
                var parameters = new
                {
                    idEstacionamento = model.idEstacionamento,
                    dtEntrada = model.dtEntrada,
                    dtSaida = model.dtSaida,
                    idManobristraEntrada = model.manobristaEntrada.idManobrista,
                    idManobristaSaida = model.manobristaSaida.idManobrista,
                    idCarro = model.carro.idCarro
                };
                string strSql = $@"update Estacionamento 
                                      set dtEntrada=@dtEntrada, 
                                          dtSaida = @dtSaida, 
                                          idManobristraEntrada = @idManobristraEntrada,
                                          idManobristaSaida = @idManobristaSaida,
                                          idCarro = @idCarro
                                    where idEstacionamento = @idEstacionamento";
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
                string strSql = $"delete from Estacionamento where idEstacionamento = @Id";
                dbConn.Execute(strSql, parameters);
            }

        }
    }
}
