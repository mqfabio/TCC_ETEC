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

     
        public async Task<Usuario> BuscarPorEmail(string email)
        {
           
            try
            {
                using (var conexao = new SqlConnection(local))
                {
                    var query = @"select  
                                        idUsuario, 
                                        senha, 
                                        codUE, 
                                        RM, 
                                        CPF, 
                                        RG, 
                                        dataNascimento, 
                                        nomeUsuario, 
                                        email, 
                                        statusUsuario, 
                                        perfil, 
                                        titulacao, 
                                        cargo 
                                from 
                                    usuario 
                                Where email = @email and statusUsuario = 0 ";

                    var param = new { email = email};
                    conexao.Open();
                    var resultado = await conexao.QueryAsync<Usuario>(query, param);

                    return resultado.FirstOrDefault();

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Usuario> BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                using (var conexao = new SqlConnection(local))
                {
                    var query = @"select  
                                        idUsuario, 
                                        senha, 
                                        codUE, 
                                        RM, 
                                        CPF, 
                                        RG, 
                                        dataNascimento, 
                                        nomeUsuario, 
                                        email, 
                                        statusUsuario, 
                                        perfil, 
                                        titulacao, 
                                        cargo 
                                from 
                                        usuario 
                                Where senha = @senha and email = @email and statusUsuario = 0 ";

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

        public async Task<bool> Cadastrar(Usuario usuario)
        {
            try
            {
                using (var conexao = new SqlConnection(local))
                {
                    var query = @"INSERT INTO [dbo].[usuario]
                                ( senha, codUE, RM, CPF, RG, dataNascimento, nomeUsuario, email, statusUsuario, perfil, titulacao, cargo)
                            Values
                                (@Senha, @CodUE, @RM, @CPF, @RG, @DataNascimento, @NomeUsuario, @email,@StatusUsuario, @Perfil, @Titulacao, @cargo)";

                    var validacao = await BuscarPorEmail(usuario.Email);
                    if (validacao == null)
                    {
                        var resultado = await conexao.ExecuteAsync(query, usuario, commandType: CommandType.Text);
                        return resultado == 1;
                    }

                    return false;

                    
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public async Task<IEnumerable<Usuario>> BuscarTodos()
        {
            try
            {
                using (var conexao = new SqlConnection(local))
                {
                    var query = @"select  IdUsuario, Senha, CodUE, RM, CPF, RG, DataNascimento, NomeUsuario, Email, Cargo, 
                                          StatusUsuario, Perfil from usuario";
                    var resultado = await conexao.QueryAsync<Usuario>(query);

                    return resultado;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public async Task<bool> Alterar(Usuario usuario)
        {
            try
            {
                using (var conexao = new SqlConnection(somee))
                {
                    var query = @"UPDATE [dbo].[usuario] set
                                senha = @senha, 
                                codUE = @codUE, 
                                RM = @RM, 
                                CPF = CPF, 
                                RG = RG, 
                                dataNascimento = @dataNascimento, 
                                nomeUsuario = @nomeUsuario, 
                                email = @email, 
                                cargo = @cargo, 
                                statusUsuario = @statusUsuario, 
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
    Task<bool> Cadastrar(Usuario servidor);
    Task<IEnumerable<Usuario>> BuscarTodos();
    Task<Usuario> BuscarPorEmailESenha(string nome, string senha);
    Task<bool> Alterar(Usuario usuario);
    Task<Usuario> BuscarPorEmail(string email);
}

