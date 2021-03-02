using System;
using System.Threading.Tasks;

namespace TCC.Models
{
    public class Servidor : IServidor
    {
        public int IdServidor { get; set; }
        public int CodUE { get; set; }
        public int Usuario_RM { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTime DataNascimento { get; set; }
        public string NomeServidor { get; set; }
        public string Email { get; set; }
        public string Cargo { get; set; }
        public string StatusServidor { get; set; }

        public Task<bool> AlterarAsync(Servidor servidor)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CadastrarAsync(Servidor servidor)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InativarAsync(int idServidor)
        {
            throw new NotImplementedException();
        }
    }

    public interface IServidor
    {
        Task<bool> CadastrarAsync(Servidor servidor);
        Task<bool> AlterarAsync(Servidor servidor);
        Task<bool> InativarAsync(int idServidor);
    }
}