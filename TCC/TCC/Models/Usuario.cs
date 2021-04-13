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

        public async Task<bool> Cadastrar(Usuario servidor)
        {
            var resultado = await _usuarioRepositorio.Cdastrar(servidor);
            return resultado;
        }

        public Task<bool> Inativar(int idServidor)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Usuario>> BuscarTodos()
        {
            var resultado = await _usuarioRepositorio.BuscarTodos();
            return resultado;
        }

        public async Task<Usuario> PegarPeloEmailSenha(string email, string senha)
        {
            var resultado = await _usuarioRepositorio.BuscarPorEmailESenha(email, senha);
            return resultado;
        }

        public async Task<Usuario> PegarPeloEmail(string email)
        {
            var resultado = await _usuarioRepositorio.BuscarPorEmail(email);
            return resultado;
        }


        public async Task<bool> Alterar(Usuario usuario)
        {
            var resultado = await _usuarioRepositorio.Alterar(usuario);
            return resultado;
        }

    }

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