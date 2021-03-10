using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using TCC.Models;

namespace TCC.Data
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        public async Task<bool> CadastrarAsync(Usuario usuario)
        {
            try
            {
                using (var conexao = new SqlConnection("Server=DESKTOP-6IG361V;Database=TCC_ETC;Trusted_Connection=True;"))
                {
                    var query = @"INSERT INTO [dbo].[usuario] 
                                   (senha ,perfil ,nome)
                             VALUES
                                   (@senha, @perfil, @nome)";

                    var resultado = await conexao.ExecuteAsync(query, usuario, commandType: CommandType.Text);

                    return resultado == 1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Usuario>> BuscarTodos()
        {
            try
            {
                using (var conexao = new SqlConnection("Server=DESKTOP-6IG361V;Database=TCC_ETC;Trusted_Connection=True;"))
                {
                    var query = @"select  RM, Senha, Perfil, Nome from Usuario";
                    var resultado = await conexao.QueryAsync<Usuario>(query);

                    return resultado;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }

    public interface IUsuarioRepositorio
    {
        Task<bool> CadastrarAsync(Usuario usuario);
        Task<IEnumerable<Usuario>> BuscarTodos();
    }
}
