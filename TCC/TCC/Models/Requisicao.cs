using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.Models
{
    public class Requisicao
    {
        public int IdRequisicao { get; set; }
        public int IdServidor { get; set; }
        public DateTime DataRequisicao { get; set; }
        public string Assunto { get; set; }
        public string Descricao { get; set; }
        //public Blog AnexoDocumento { get; set; }
        public string StatusRequisicao { get; set; }
        public string situacao { get; set; }
        public string motivo { get; set; }
    }
}
