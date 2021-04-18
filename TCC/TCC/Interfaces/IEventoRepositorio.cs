using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.Models;

namespace TCC.Interfaces
{
    public interface IEventoRepositorio
    {
        Task<bool> Cadastrar(Evento evento);

        Task<bool> Deletar(int id);

        Task<Evento> BuscarPorNome(string nome);

        Task<IEnumerable<Evento>> BuscarTodos();

        Task<bool> AlterarAsync(Evento evento);

        Task<List<EventoComUsuariosParticipantes>> BuscarEventosPeloNomeouDataTrazendoUsuario(string nomeEvento, DateTime dataInicio, DateTime datafim);

        Task<IEnumerable<Evento>> BuscarPeloRm(int rm);
    }
}
