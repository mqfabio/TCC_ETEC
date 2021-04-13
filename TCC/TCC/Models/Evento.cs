﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TCC.Data;
using TCC.DTO;
using TCC.Enums;

namespace TCC.Models
{
    public class Evento : IEvento
    {
        public int IdEvento { get; set; }
        //public int IdServidor { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataEvento { get; set; }
        public StatusEventoEnum StatusEvento { get; set; }

        /*[JsonIgnore]
        public DateTime HoraDb { get; set; }

        public string Hora { get => HoraDb.ToString("HH:mm"); }
        public string NomeServidor { get; set; }
        public string RG { get; set; }*/

       



        private readonly IEventoRepositorio _eventoRepositorio;

        public Evento(IEventoRepositorio eventoRepositorio)
        {
            _eventoRepositorio = eventoRepositorio;
        }


        public Evento()
        {

        }
        public Evento(string nome, string descricao, DateTime data_evento, string nomeServidor, StatusEventoEnum statusEvento)
        {
            
            Nome = nome;
            Descricao = descricao;
            DataEvento = data_evento;
            StatusEvento = statusEvento;

            
        }

        public async Task<bool> Cadastrar(Evento evento)
        {
            var resultado = await _eventoRepositorio.Cadastrar(evento);

            return resultado;
        }

        public async Task<bool> Alterar(Evento evento)
        {
            var resultado = await _eventoRepositorio.AlterarAsync(evento);
            return resultado;
        }

        public async Task<bool> Excluir(int idEvento)
        {
            var resultado = await _eventoRepositorio.Deletar(idEvento);
            return resultado;
        }

        public async Task<Evento> PegarPeloNome(string nome)
        {
            var resultado = await _eventoRepositorio.BuscarPorNome(nome);
            return resultado;
        }

        public async Task<IEnumerable<Evento>> BuscarTodos()
        {
            var resultado = await _eventoRepositorio.BuscarTodos();
            return resultado;
        }

        public async Task<List<EventoComUsuariosParticipantes>> BuscarEventosPeloNomeouDataTrazendoUsuario(string nomeEvento, DateTime dataInicio, DateTime datafim)
        {
            var resultado = await _eventoRepositorio.BuscarEventosPeloNomeouDataTrazendoUsuario(nomeEvento, dataInicio, datafim);
            return resultado;
        }

        public async Task<IEnumerable<Evento>> BuscarPeloRm(int rm)
        {
            var resultado = await _eventoRepositorio.BuscarPeloRm(rm);
            return resultado;
        }
    }



    public interface IEvento
    {
        Task<bool> Cadastrar(Evento evento);
        Task<bool> Alterar(Evento evento);
        Task<bool> Excluir(int idEvento);
        Task<Evento> PegarPeloNome(string nome);
        Task<IEnumerable<Evento>> BuscarTodos();
        Task<List<EventoComUsuariosParticipantes>> BuscarEventosPeloNomeouDataTrazendoUsuario(string nomeEvento, DateTime dataInicio, DateTime datafim);
        Task<IEnumerable<Evento>> BuscarPeloRm(int rm);




        //IEnumerable<Evento> ConsultarInformacoes();
        //IEnumerable<Servidor> ConsultarParticipacoesEvento(int idEvento);
        //IEnumerable<Requisicao> ConsultarRequisicoes();
    }
}
