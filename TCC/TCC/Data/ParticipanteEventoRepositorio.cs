using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TCC.Models;

namespace TCC.Data
{
    public class ParticipanteEventoRepositorio : IParticipanteEventoRepositorio
    {
        string local = "Server=DESKTOP-6IG361V;Database=TCC_ETC;Trusted_Connection=True";
        string somee = "workstation id=TccEtec.mssql.somee.com;packet size = 4096; user id = Giselle_SQLLogin_1; pwd=a7autn81ou;data source = TccEtec.mssql.somee.com; persist security info=False;initial catalog = TccEtec";

        public async Task<bool> Cadastrar(Participante_evento pe)
        {
            try
            {
                using (var conexao = new SqlConnection(local))
                {
                    var query = @"INSERT INTO [dbo].[participante_evento]
                            (idEvento, idUsuario)
                        values
                            (@IdEvento, @IdUsuario)";

                    var resultado = await conexao.ExecuteAsync(query, pe, commandType: CommandType.Text);
                    return resultado == 1;
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

    }

    public interface IParticipanteEventoRepositorio
    {
        Task<bool> Cadastrar(Participante_evento pe);
    }
}
