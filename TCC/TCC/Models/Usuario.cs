using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TCC.Data;
using TCC.Enums;

namespace TCC.Models
{
    public class Usuario : IUsuario
    {
        

        public int IdUsuario { get; set; }
        public int CodUE { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTime DataNascimento { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Cargo { get; set; }
        public StatusUsuarioEnum StatusUsuario { get; set; }
        public string Titulacao { get; set; }
        public string Senha { get; set; }
        public int RM { get; set; }
        public PerfilEnum Perfil { get; set; }


        public Usuario()
        {
        }


        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public Usuario(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        //public async Task<bool> AlterarAsync(Servidor servidor)
        //{
        //    var resultado = await _servidorRepositorio.AlterarAsync(servidor);
        //    return resultado;
        //}

        public async Task<bool> CadastrarAsync(Usuario servidor)
        {
            var resultado = await _usuarioRepositorio.CdastrarAsync(servidor);
            return resultado;
        }

        public Task<bool> InativarAsync(int idServidor)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Usuario>> BuscarTodosAsync()
        {
            var resultado = await _usuarioRepositorio.BuscarTodosAsync();
            return resultado;
        }

        public async Task<Usuario> PegarPeloNome(string email, string senha)
        {
            var resultado = await _usuarioRepositorio.BuscarPorNomeESenha(email, senha);
            return resultado;
        }

        public async Task<Usuario> VerificarUsuarioAtivo(Usuario usuario)
        {
            var resultado = await _usuarioRepositorio.VerificarUsuarioAtivo(usuario);
            return resultado;
        }

        public async Task<bool> AlterarAsync(Usuario usuario)
        {
            var resultado = await _usuarioRepositorio.AlterarAsync(usuario);
            return resultado;
        }

    }

    public interface IUsuario
    {
        Task<bool> CadastrarAsync(Usuario servidor);
        //Task<bool> AlterarAsync(Servidor servidor);
        Task<bool> InativarAsync(int idServidor);
        Task<IEnumerable<Usuario>> BuscarTodosAsync();
        Task<Usuario> PegarPeloNome(string email, string senha);
        Task<bool> AlterarAsync(Usuario idUsuario);
        Task<Usuario> VerificarUsuarioAtivo(Usuario usuario);
    }
}