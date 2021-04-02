using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.Data;


namespace TCC.Models
{
    public class Participante_evento : IParticipante_evento
    {
        

        public int IdEvento { get; set; }
        public int IdServidor { get; set; }



        private readonly IParticipanteEventoRepositorio _participanteEventoRepositorio;
        public Participante_evento(IParticipanteEventoRepositorio participanteEventoRepositorio)
        {
            _participanteEventoRepositorio = participanteEventoRepositorio;
        }



        public async Task<bool> CadastrarAsync(Participante_evento pe)
        {
            var resultado = await _participanteEventoRepositorio.Cadastrar(pe);
            return resultado;
        }


    }

    public interface IParticipante_evento
    {
        Task<bool> CadastrarAsync(Participante_evento pe);
    }
}
