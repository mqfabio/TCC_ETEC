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
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        //public async Task<bool> AlterarAsync(Servidor servidor)
        //{
        //    try
        //    {
        //        using (var conexao = new SqlConnection("Server=DESKTOP-6IG361V;Database=TCC_ETC;Trusted_Connection=True;"))
        //        {
        //            var query = @"UPDATE [dbo].[evento] set
        //                        CodUE = @CodUE ,RM = @RM ,CPF = @CPF, RG = @RG ,dataNascimento = @dataNascimento ,
        //                        nomeServidor = @nomeServidor, email = @email, cargo = @cargo, statusServidor = @statusServidor
        //                    WHERE idServidor = @idServidor";

        //            var resultado = await conexao.ExecuteAsync(query, servidor, commandType: CommandType.Text);

        //            return resultado == 1;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}   
        
        public async Task<bool> CdastrarAsync(Usuario servidor)
        {
            try
            {
                using (var conexao = new SqlConnection("Server=DESKTOP-6IG361V;Database=TCC_ETC;Trusted_Connection=True;"))
                {
                    var query = @"INSERT INTO [dbo].[usuario]
                                ( senha, codUE ,RM ,CPF ,RG ,dataNascimento , nomeUsuario, email, cargo, statusServidor, perfil)
                            Values
                                (@Senha, @CodUE, @RM, @CPF, @RG, @DataNascimento, @NomeUsuario, @email, @Cargo, @StatusServidor, @Perfil)";

                    var resultado = await conexao.ExecuteAsync(query, servidor, commandType: CommandType.Text);

                    return resultado == 1;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
           
        }
        
        public async Task<IEnumerable<Usuario>> BuscarTodosAsync()
        {
            try
            {
                using (var conexao = new SqlConnection("Server=DESKTOP-6IG361V;Database=TCC_ETC;Trusted_Connection=True;"))
                {
                    var query = @"select  IdUsuario, Senha, CodUE, RM, CPF, RG, DataNascimento, NomeUsuario, Email, Cargo StatusServidor, Perfil from usuario";
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
}
public interface IUsuarioRepositorio 
{
    //Task<bool> AlterarAsync(Servidor servidor);
    Task<bool> CdastrarAsync(Usuario servidor);
    Task<IEnumerable<Usuario>> BuscarTodosAsync();
}

