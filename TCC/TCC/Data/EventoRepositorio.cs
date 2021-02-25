using System.Data.SqlClient;
using System.Threading.Tasks;
using TCC.Models;
using Dapper;
using System.Data;
using System;
using System.Collections.Generic;

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
            return true;
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

    }
    public interface IEventoRepositorio
    {
        Task<bool> CadastrarAsync(Evento evento);

        Task<bool> DeletarAsync(int id);
    }
}
