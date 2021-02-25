using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TCC.Data;

namespace TCC.Models
{
    public class Evento : IEvento
    {
        public int IdEvento { get; set; }
        public int IdServidor { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime Data_Evento { get; set; }
        public string StatusEvento { get; set; }
        public DateTime Hora { get; set; }


        private readonly IEventoRepositorio _eventoRepositorio;

        public Evento(IEventoRepositorio eventoRepositorio)
        {
            _eventoRepositorio = eventoRepositorio;
        }


        public Evento()
        {

        }
        public Evento(int idServidor, string nome, string descricao, DateTime data_evento, string statusEvento, DateTime hora)
        {
            IdServidor = idServidor;
            Nome = nome;
            Descricao = descricao;
            Data_Evento = data_evento;
            StatusEvento = statusEvento;
            Hora = hora;
        }

        public async Task<bool> CadastrarAsync(Evento evento)
        {
            var resultado = await _eventoRepositorio.CadastrarAsync(evento);

            return resultado;
        }

        public async Task<bool> AlterarAsync(Evento evento)
        {
            return true;
        }

        public async Task<bool> ExcluirAsync(int idEvento)
        {
            var resultado = await _eventoRepositorio.DeletarAsync(idEvento);
            return true;
        }
    }



    public interface IEvento
    {
        Task<bool> CadastrarAsync(Evento evento);
        Task<bool> AlterarAsync(Evento evento);
        Task<bool> ExcluirAsync(int idEvento);
 


        //IEnumerable<Evento> ConsultarInformacoes();
        //IEnumerable<Servidor> ConsultarParticipacoesEvento(int idEvento);
        //IEnumerable<Requisicao> ConsultarRequisicoes();
    }
}
