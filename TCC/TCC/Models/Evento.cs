using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TCC.Data;

namespace TCC.Models
{
    public class Evento : IEvento
    {
        public int IdEvento { get; set; }
        //public int IdServidor { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime Data_Evento { get; set; }
        [JsonIgnore]
        public DateTime HoraDb { get; set; }

        public string Hora { get => HoraDb.ToString("HH:mm"); }
        public string NomeServidor { get; set; }
        public string RG { get; set; }
        public string StatusEvento { get; set; }



        private readonly IEventoRepositorio _eventoRepositorio;

        public Evento(IEventoRepositorio eventoRepositorio)
        {
            _eventoRepositorio = eventoRepositorio;
        }


        public Evento()
        {

        }
        public Evento(string nome, string descricao, DateTime data_evento, string nomeServidor, string rg,string statusEvento)
        {
            
            Nome = nome;
            Descricao = descricao;
            Data_Evento = data_evento;
            StatusEvento = statusEvento;
            NomeServidor = nomeServidor;
            RG = rg;
            
        }

        public async Task<bool> CadastrarAsync(Evento evento)
        {
            var resultado = await _eventoRepositorio.CadastrarAsync(evento);

            return resultado;
        }

        public async Task<bool> AlterarAsync(Evento evento)
        {
            var resultado = await _eventoRepositorio.AlterarAsync(evento);
            return resultado;
        }

        public async Task<bool> ExcluirAsync(int idEvento)
        {
            var resultado = await _eventoRepositorio.DeletarAsync(idEvento);
            return resultado;
        }

        public async Task<Evento> PegarPeloId(int id)
        {
            var resultado = await _eventoRepositorio.BuscarPorId(id);
            return resultado;
        }

        public async Task<IEnumerable<Evento>> BuscarTodos()
        {
            var resultado = await _eventoRepositorio.BuscarTodos();
            return resultado;
        }
    }



    public interface IEvento
    {
        Task<bool> CadastrarAsync(Evento evento);
        Task<bool> AlterarAsync(Evento evento);
        Task<bool> ExcluirAsync(int idEvento);
        Task<Evento> PegarPeloId(int id);
        Task<IEnumerable<Evento>> BuscarTodos();



        //IEnumerable<Evento> ConsultarInformacoes();
        //IEnumerable<Servidor> ConsultarParticipacoesEvento(int idEvento);
        //IEnumerable<Requisicao> ConsultarRequisicoes();
    }
}
