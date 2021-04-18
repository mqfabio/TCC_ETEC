using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.Models;

namespace TCC.Interfaces
{
    public interface IParticipanteEventoRepositorio
    {
        Task<bool> Cadastrar(Participante_evento pe);
        Task<Participante_evento> BuscarPeloUsuario(int idUsuario, int idEvento);
        Task<bool> Deletar(int idUsuario, int idEvento);
    }
}
