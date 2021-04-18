using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.Data;
using TCC.Interfaces;

namespace TCC.Models
{
    public class Participante_evento : IParticipante_evento
    {
        

        public int IdEvento { get; set; }
        public int IdUsuario { get; set; }



        private readonly IParticipanteEventoRepositorio _participanteEventoRepositorio;
        public Participante_evento(IParticipanteEventoRepositorio participanteEventoRepositorio)
        {
            _participanteEventoRepositorio = participanteEventoRepositorio;
        }

        public Participante_evento()
        {
                
        }


        public async Task<bool> CadastrarAsync(Participante_evento pe)
        {
            return await _participanteEventoRepositorio.Cadastrar(pe);  
        }

        public async Task<Participante_evento> BuscarPeloUsuario(int idUsuario, int idEvento)
        {
            return await _participanteEventoRepositorio.BuscarPeloUsuario(idUsuario, idEvento);
        }

        public async Task<bool> Deletar(int idUsuario, int idevento)
        {
            return await _participanteEventoRepositorio.Deletar(idUsuario, idevento);
        }


    }

    public interface IParticipante_evento
    {
        Task<bool> CadastrarAsync(Participante_evento pe);
        Task<Participante_evento> BuscarPeloUsuario(int idUsuario, int idEvento);
        Task<bool> Deletar(int idUsuario, int idevento);
    }
}
