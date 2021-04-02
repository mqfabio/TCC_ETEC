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
        string local = "Server=DESKTOP-6IG361V;Database=TCC_ETC;Trusted_Connection=True";
        string somee = "workstation id=TccEtec.mssql.somee.com;packet size = 4096; user id = Giselle_SQLLogin_1; pwd=a7autn81ou;data source = TccEtec.mssql.somee.com; persist security info=False;initial catalog = TccEtec";


        //public async Task<bool> AlterarAsync(Usuario usuario)
        //{
        //    try
        //    {
        //        using (var conexao = new SqlConnection(local))
        //        {
        //            var query = @"UPDATE [dbo].[evento] set
        //                        CodUE = @CodUE , CPF = @CPF, RG = @RG ,dataNascimento = @dataNascimento ,
        //                        nomeUsuario = @nomeUsuario, email = @email, cargo = @cargo, statusUsuario = 
        //                        @statusUsuario, titulacao = @titulacao, senha = @senha, RM = @RM, perfil = @perfil
        //                    WHERE idUsuario = @idUsuario";

        //            var resultado = await conexao.ExecuteAsync(query, usuario, commandType: CommandType.Text);

        //            return resultado == 1;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}   

        public async Task<Usuario> VerificarUsuarioAtivo(Usuario usuario)
        {
            try
            {
                var resultado =  await BuscarPorNomeESenha(usuario.Email, usuario.Senha);

                if (resultado.StatusUsuario == 0)
                    return resultado;
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message + "Usuario nao existe");
            }



        }
        public async Task<Usuario> BuscarPorNomeESenha(string email, string senha)
        {
            try
            {
                using (var conexao = new SqlConnection(local))
                {
                    var query = @"select  idUsuario, senha, codUE, RM, CPF, RG, dataNascimento, nomeUsuario, email, statusUsuario, perfil, titulacao, cargo from usuario Where senha = @senha and email = @email  ";

                    var param = new { email = email, senha = senha };
                    conexao.Open();
                    var resultado = await conexao.QueryAsync<Usuario>(query, param);
                    var resultado2 = resultado.FirstOrDefault();

                    return resultado.FirstOrDefault();

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> CdastrarAsync(Usuario servidor)
        {
            try
            {
                using (var conexao = new SqlConnection(local))
                {
                    var query = @"INSERT INTO [dbo].[usuario]
                                ( senha, codUE, RM, CPF, RG, dataNascimento, nomeUsuario, email, statusUsuario, perfil, titulacao, cargo)
                            Values
                                (@Senha, @CodUE, @RM, @CPF, @RG, @DataNascimento, @NomeUsuario, @email,@StatusUsuario, @Perfil, @Titulacao, @cargo)";

                    var resultado = await conexao.ExecuteAsync(query, servidor, commandType: CommandType.Text);
                    Console.WriteLine(resultado);
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
                using (var conexao = new SqlConnection(local))
                {
                    var query = @"select  IdUsuario, Senha, CodUE, RM, CPF, RG, DataNascimento, NomeUsuario, Email, Cargo, StatusUsuario, Perfil from usuario";
                    var resultado = await conexao.QueryAsync<Usuario>(query);

                    return resultado;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public async Task<bool> AlterarAsync(Usuario usuario)
        {
            try
            {
                using (var conexao = new SqlConnection(local))
                {
                    var query = @"UPDATE [dbo].[usuario] set
                                senha = @senha, codUE = @codUE, RM = @RM, CPF = CPF, RG = RG, dataNascimento = @dataNascimento, 
                                nomeUsuario = @nomeUsuario, email = @email, cargo = @cargo, statusUsuario = @statusUsuario, 
                                perfil = @perfil
                            WHERE idUSuario = @idUsuario";

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
}
public interface IUsuarioRepositorio 
{
    //Task<bool> AlterarAsync(Servidor servidor);
    Task<bool> CdastrarAsync(Usuario servidor);
    Task<IEnumerable<Usuario>> BuscarTodosAsync();
    Task<Usuario> BuscarPorNomeESenha(string nome, string senha);
    Task<bool> AlterarAsync(Usuario usuario);
    Task<Usuario> VerificarUsuarioAtivo(Usuario usuario);
}

