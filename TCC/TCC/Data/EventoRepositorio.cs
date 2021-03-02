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
        public async Task<bool> CadastrarAsync(Evento evento)
        {
            try
            {
                using (var conexao = new SqlConnection("Server=DESKTOP-6IG361V;Database=TCC;Trusted_Connection=True;"))
                {
                    var query = @"INSERT INTO [dbo].[evento]
                                (idServidor ,nome ,descricao ,data_evento ,hora ,statusEvento)
                            Values
                                (@IdServidor, @Nome, @Descricao, @Data_Evento, @hora, @StatusEvento)";

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
                using (var conexao = new SqlConnection("Server=DESKTOP-6IG361V;Database=TCC;Trusted_Connection=True;"))
                {
                    var query = @"UPDATE [dbo].[evento] set
                                idServidor = @idServidor ,nome = @nome ,descricao = @descricao, data_evento = @data_evento ,hora = Convert(Time, @hora),statusEvento = @statusEvento
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
                using (var conexao = new SqlConnection("Server=DESKTOP-6IG361V;Database=TCC;Trusted_Connection=True;"))
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

        public async Task<Evento> BuscarPorId(int id)
        {
            try
            {
                using (var conexao = new SqlConnection("Server=DESKTOP-6IG361V;Database=TCC;Trusted_Connection=True;"))
                {
                    var query = @"select  idEvento, idServidor, nome,descricao,data_evento, Convert(DATETIME, hora) As HoraDb from evento Where idEvento = @id";

                    var param = new { id = id };
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
                using (var conexao = new SqlConnection("Server=DESKTOP-6IG361V;Database=TCC;Trusted_Connection=True;"))
                {
                    var query = @"select idEvento, idServidor, nome, descricao, data_evento, Convert(DATETIME, hora) As HoraDb from evento ";

                    var resultado = await conexao.QueryAsync<Evento>(query);

                    return resultado;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
    public interface IEventoRepositorio
    {
        Task<bool> CadastrarAsync(Evento evento);

        Task<bool> DeletarAsync(int id);

        Task<Evento> BuscarPorId(int id);

        Task<IEnumerable<Evento>> BuscarTodos();

        Task<bool> AlterarAsync(Evento evento);



        //@"UPDATE [dbo].[evento] set
        //                        idServidor = @idServidor ,nome = @nome ,descricao = @descricao, data_evento = @data_evento ,hora = Convert(Time, @hora),statusEvento = @statusEvento
        //                    WHERE idEvento = @idEvento";
    }
}
