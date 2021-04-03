using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TCC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;


namespace TCC.Controllers
{
    [Authorize]
    [ApiController]
    [Route("ParticipanteEvento")]
    public class ParticipanteEventoController : ControllerBase
    {
        private readonly IParticipante_evento _participante_Evento;

        public ParticipanteEventoController(IParticipante_evento participante_Evento)
        {
            _participante_Evento = participante_Evento;
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CadastrarAsync([Required][FromBody] Participante_evento pe)
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
            catch(Exception e)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro inesperado. Entre em contato com o administrador.");
            }
            throw new NotImplementedException();
        }
    }
}
