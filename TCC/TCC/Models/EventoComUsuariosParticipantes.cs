using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.Models
{
    public class EventoComUsuariosParticipantes
    {
        public int IdEvento { get; set; }
        public string Nome { get; set; }
        public List<string> NomeUsuarios { get; set; }
    }
}
