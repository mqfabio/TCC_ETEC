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
    public class ServidorRepositorio : IServidorRepositorio
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
        
        public async Task<bool> CdastrarAsync(Servidor servidor)
        {
            try
            {
                using (var conexao = new SqlConnection("Server=DESKTOP-6IG361V;Database=TCC_ETC;Trusted_Connection=True;"))
                {
                    var query = @"INSERT INTO [dbo].[servidor]
                                ( codUE ,RM ,CPF ,RG ,dataNascimento , nomeServidor, email, cargo, statusServidor)
                            Values
                                (@CodUE, @RM, @CPF, @RG, @DataNascimento, @NomeServidor, @email, @Cargo, @StatusServidor)";

                    var resultado = await conexao.ExecuteAsync(query, servidor, commandType: CommandType.Text);

                    return resultado == 1;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
           
        }

        public async Task<IEnumerable<Servidor>> BuscarTodosAsync()
        {
            try
            {
                using (var conexao = new SqlConnection("Server=DESKTOP-6IG361V;Database=TCC_ETC;Trusted_Connection=True;"))
                {
                    var query = @"select  IdServidor, CodUE, RM, CPF, RG, DataNascimento, NomeServidor, Email, Cargo StatusServidor from Servidor";
                    var resultado = await conexao.QueryAsync<Servidor>(query);

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
public interface IServidorRepositorio 
{
    //Task<bool> AlterarAsync(Servidor servidor);
    Task<bool> CdastrarAsync(Servidor servidor);
    Task<IEnumerable<Servidor>> BuscarTodosAsync();
}

