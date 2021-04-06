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
    public class RequisicaoRepositorio : IRequisicaoRepositorio
    {

        string local = "Server=DESKTOP-6IG361V;Database=TCC_ETC;Trusted_Connection=True";
        string somee = "workstation id=TccEtec.mssql.somee.com;packet size = 4096; user id = Giselle_SQLLogin_1; pwd=a7autn81ou;data source = TccEtec.mssql.somee.com; persist security info=False;initial catalog = TccEtec";

        public async Task<IEnumerable<Requisicao>> BuscarTodos()
        {
            try
            {
                using (var conexao = new SqlConnection(local))
                {
                    var query = @"select  idRequisicao, idUsuario, dataRequisicao, assunto, descricao, pathanexodocumento, 
                                statusRequisicao, situacao, motivo, titulacao from requisicao";
                    var resultado = await conexao.QueryAsync<Requisicao>(query);

                    return resultado;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> CadastrarAsync(Requisicao requisicao)
        {
            try
            {
                using (var conexao = new SqlConnection(local))
                {
                    var query = @"INSERT INTO [dbo].[requisicao]
                                (idUsuario, dataRequisicao, assunto, descricao, pathanexodocumento, 
                                statusRequisicao, situacao, motivo, titulacao)
                            Values
                                (@IdUsuario, @DataRequisicao, @Assunto, @Descricao, @Pathanexodocumento, 
                                @StatusRequisicao, @Situacao, @motivo, @Titulacao)";

                    var resultado = await conexao.ExecuteAsync(query, requisicao, commandType: CommandType.Text);

                    return resultado == 1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }

    public interface IRequisicaoRepositorio
    {
        Task<IEnumerable<Requisicao>> BuscarTodos();
        Task<bool> CadastrarAsync(Requisicao requisicao);
    }
}
