using Dapper;
using System;
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
                using (var conexao = new SqlConnection("Server=DESKTOP-6IG361V;Database=TCC;Trusted_Connection=True;"))
                {
                    var query = @"INSERT INTO [dbo].[Usuarios]
                                   (Rm ,Senha ,Perfil ,Nome)
                             VALUES
                                   (@Rm, @Senha, @Perfil, @Nome)";

                    var resultado = await conexao.ExecuteAsync(query, usuario, commandType: CommandType.Text);

                    return resultado == 1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

    public interface IUsuarioRepositorio
    {
        Task<bool> CadastrarAsync(Usuario usuario);
    }
}
