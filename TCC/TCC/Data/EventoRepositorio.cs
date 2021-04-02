using System.Data.SqlClient;
using System.Threading.Tasks;
using TCC.Models;
using Dapper;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TCC.Data
{
    public class EventoRepositorio : IEventoRepositorio
    {

        string local = "Server=DESKTOP-6IG361V;Database=TCC_ETC;Trusted_Connection=True";
        string somee = "workstation id=TccEtec.mssql.somee.com;packet size = 4096; user id = Giselle_SQLLogin_1; pwd=a7autn81ou;data source = TccEtec.mssql.somee.com; persist security info=False;initial catalog = TccEtec";
        public async Task<bool> CadastrarAsync(Evento evento)
        {
            try
            {
                using (var conexao = new SqlConnection(local))
                {
                    var query = @"INSERT INTO [dbo].[evento]
                                ( nome ,descricao ,dataEvento, statusEvento)
                            Values
                                (@Nome, @Descricao, @DataEvento, @StatusEvento)";

                    var resultado = await conexao.ExecuteAsync(query, evento, commandType: CommandType.Text);

                    return resultado == 1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<bool> AlterarAsync(Evento evento)
        {
            try
            {
                using (var conexao = new SqlConnection(local))
                {
                    var query = @"UPDATE [dbo].[evento] set
                                nome = @nome ,descricao = @descricao, dataEvento = @dataEvento, statusEvento = @statusEvento
                            WHERE idEvento = @idEvento";

                    var resultado = await conexao.ExecuteAsync(query, evento, commandType: CommandType.Text);

                    return resultado == 1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletarAsync(int id)
        {
            try
            {
                using (var conexao = new SqlConnection(local))
                {
                    var param = new { id = id };

                    var query = @"DELETE [dbo].[evento] Where IdEvento = @id";

                    var resultado = await conexao.ExecuteAsync(query, param, commandType: CommandType.Text);

                    return resultado == 1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
            
        }

        public async Task<Evento> BuscarPorNome(string nome)
        {
            try
            {                           //Server=DESKTOP-6IG361V;Database=TCC_ETC;Trusted_Connection=True;
                using (var conexao = new SqlConnection(local))
                {
                    var query = @"select  idEvento, nome, descricao, dataEvento, statusEvento from evento Where Nome = @nome";

                    var param = new { nome = nome };
                    conexao.Open();
                    var resultado = await conexao.QueryAsync<Evento>(query, param);

                    return resultado.FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<Evento>> BuscarTodos()
        {
            try
            {
                using (var conexao = new SqlConnection(local))
                {
                    var query = @"select  idEvento, nome, descricao, dataEvento, statusEvento from evento";
                    var resultado = await conexao.QueryAsync<Evento>(query);

                    return resultado;
                }
            }
            catch (Exception e)
            {
                throw   new Exception(e.Message);
            }
        }
    }
    public interface IEventoRepositorio
    {
        Task<bool> CadastrarAsync(Evento evento);

        Task<bool> DeletarAsync(int id);

        Task<Evento> BuscarPorNome(string nome);

        Task<IEnumerable<Evento>> BuscarTodos();

        Task<bool> AlterarAsync(Evento evento);



        //@"UPDATE [dbo].[evento] set
        //                        idServidor = @idServidor ,nome = @nome ,descricao = @descricao, data_evento = @data_evento ,hora = Convert(Time, @hora),statusEvento = @statusEvento
        //                    WHERE idEvento = @idEvento";
    }
}
