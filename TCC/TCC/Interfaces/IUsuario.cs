using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.Models;

namespace TCC.Interfaces
{
    public interface IUsuario
    {
        Task<bool> Cadastrar(Usuario servidor);
        //Task<bool> AlterarAsync(Servidor servidor);
        Task<bool> Inativar(int idServidor);
        Task<IEnumerable<Usuario>> BuscarTodos();
        Task<Usuario> PegarPeloEmailSenha(string email, string senha);
        Task<bool> Alterar(Usuario idUsuario);
        Task<Usuario> PegarPeloEmail(string email);
    }
}
