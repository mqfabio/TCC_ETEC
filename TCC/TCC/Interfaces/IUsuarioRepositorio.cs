using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.Models;

namespace TCC.Interfaces
{
    public interface IUsuarioRepositorio
    {
        //Task<bool> AlterarAsync(Servidor servidor);
        Task<bool> Cadastrar(Usuario servidor);
        Task<IEnumerable<Usuario>> BuscarTodos();
        Task<Usuario> BuscarPorEmailESenha(string nome, string senha);
        Task<bool> Alterar(Usuario usuario);
        Task<Usuario> BuscarPorEmail(string email);
    }
}
