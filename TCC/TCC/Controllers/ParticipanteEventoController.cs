using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using TCC.Models;
using System.Threading.Tasks;

namespace TCC.Controllers
{
    [Authorize]
    [ApiController]
    [Route("ParticipanteEvento")]
    public class ParticipanteEventoController : ControllerBase
    {
        private readonly IParticipante_evento _participante_Evento;

        public ParticipanteEventoController(IParticipante_evento participante_evento)
        {
            _participante_Evento = participante_evento;
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CadastrarAsync(Participante_evento pe)
        {
            var resultado = await _participante_Evento.CadastrarAsync(pe);
            try
            {
                if (resultado)
                {
                    return StatusCode(HttpStatusCode.Created.GetHashCode());
                }
                else
                {
                    return StatusCode(HttpStatusCode.InternalServerError.GetHashCode());
                }
            }
            catch (Exception e)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro inesperado. Entre em contato com o administrador.");
            }
            throw new NotImplementedException();
        }

    }
}
