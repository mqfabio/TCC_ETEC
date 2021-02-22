using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TCC.Models;

namespace TCC.Controllers
{
    [ApiController]
    [Route("evento")]
    public class EventoController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CadastrarAsycn([Required][FromBody] Evento evento)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public async Task<IActionResult> AlterarAsycn([Required][FromBody] Evento evento)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public async Task<IActionResult> ExcluirAsycn([Required] int idEvento)
        {
            throw new NotImplementedException();
        }
    }
}
