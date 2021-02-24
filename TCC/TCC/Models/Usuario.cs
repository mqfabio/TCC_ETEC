﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.Data;

namespace TCC.Models
{
    public class Usuario : IUsuario
    {
        public int Rm { get; set; }
        public string Senha { get; set; }
        public string Perfil { get; set; }
        public string Nome { get; set; }

        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public Usuario(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public Usuario()
        {

        }

        //public Usuario(string senha, string perfil, string nome)
        //{
        //    Senha = senha;
        //    Perfil = perfil;
        //    Nome = nome;
        //}

        public async Task<bool> CadastrarAsync(Usuario usuario)
        {
            var resultado = await _usuarioRepositorio.CadastrarAsync(usuario);

            return resultado;
        }
    }

    public interface IUsuario
    {
        Task<bool> CadastrarAsync(Usuario usuario);
    }

}
