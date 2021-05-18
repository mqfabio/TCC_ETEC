﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.Models;

namespace TCC.Interfaces
{
    public interface IEvento
    {
        Task<bool> CadastrarAsync(Evento evento);
        Task<bool> AlterarAsync(Evento evento);
        Task<bool> ExcluirAsync(int idEvento);
        Task<Evento> PegarPeloNomeAsync(string nome);
        Task<IEnumerable<Evento>> BuscarTodosAsync();
        Task<List<EventoComUsuariosParticipantes>> BuscarEventosPeloNomeouDataTrazendoUsuarioAsync(string nomeEvento, DateTime? dataInicio, DateTime? datafim);
        Task<IEnumerable<Evento>> BuscarPeloRmAsync(int rm);
        Task<IEnumerable<Evento>> BuscarPorNomeOuData(DateTime dataInicio, DateTime dataFim);


        //IEnumerable<Evento> ConsultarInformacoes();
        //IEnumerable<Servidor> ConsultarParticipacoesEvento(int idEvento);
        //IEnumerable<Requisicao> ConsultarRequisicoes();
    }
}
