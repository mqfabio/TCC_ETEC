using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.Models;

namespace TCC.Interfaces
{
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
