using System;
using System.Threading.Tasks;

namespace TCC.Models
{
    public class Servidor
    {
        public int id { get; set; }
        public int usuario_rm { get; set; }
        public string cpf { get; set; }
        public string rg { get; set; }
        public DateTime dataNascimento { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string cargo { get; set; }
        public string statusServidor { get; set; }
    }

    public interface IServidor
    {
        Task<bool> CadastrarAsync(Servidor servidor);
        Task<bool> AlterarAsync(Servidor servidor);
        Task<bool> InativarAsync(int idServidor);
    }
}