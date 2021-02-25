using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TCC.Models;

namespace TCC.Controllers
{
    [ApiController]
    [Route("evento")]
    public class EventoController : ControllerBase
    {
        private readonly IEvento _evento;

        public EventoController(IEvento evento)
        {
            _evento = evento;
        }


        [HttpPost]
        public async Task<IActionResult> CadastrarAsycn([Required][FromBody] Evento evento)
        {
            var resultado = await _evento.CadastrarAsync(evento);

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
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Erro inesperado. Entre em contato com o administrador.");
            }

            throw new NotImplementedException();
        }

        [HttpPut]
        public async Task<IActionResult> AlterarAsycn([Required][FromBody] Evento evento)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirAsycn(int id)
        {
            var resultado = await _evento.ExcluirAsync(id);
            try
            {
                if (resultado)
                {
                    return StatusCode(HttpStatusCode.OK.GetHashCode());
                }

                else
                {
                    return StatusCode(HttpStatusCode.InternalServerError.GetHashCode());
                }
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode());
            }
            throw new NotImplementedException();
        }
        
    }
}
