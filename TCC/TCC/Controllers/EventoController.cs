using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using TCC.DTO;
using TCC.Interfaces;
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Cadastrar([Required][FromBody] Evento evento)
        {
            var resultado = await _evento.Cadastrar(evento);

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


        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Alterar([Required][FromBody] Evento evento)
        {
            var resultado = await _evento.Alterar(evento);
            try
            {
                if (resultado)
                {
                    return StatusCode(HttpStatusCode.Created.GetHashCode());
                }

                else
                {
                    return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "Não foi possivel atualizar o evento.");
                }
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }

            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Excluir(int id)
        {
            var resultado = await _evento.Excluir(id);
            try
            {
                if (resultado)
                {
                    return StatusCode(HttpStatusCode.OK.GetHashCode());
                }

                else
                {
                    return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), "O evento não foi excluido.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode());
            }
            throw new NotImplementedException();
        }

        //[HttpGet("{nome}")]
        public async Task<IActionResult> PegarPeloNome(string nome)
        {
            var resultado = await _evento.PegarPeloNome(nome);
            try
            {
                if (resultado != null)
                {
                    return Ok(resultado);
                }

                else
                {
                    return BadRequest("Insira um nome valido");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode());
            }
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodos()
        {
            var resultado = await _evento.BuscarTodos();
            try
            {
                if (resultado != null)
                    return Ok(resultado);

                else
                    return NotFound();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("{nomeEvento}/{dataInicio:DateTime}/{datafim}")]
        public async Task<ActionResult<List<Evento>>> BuscarEventosPeloNomeouDataTrazendoUsuario(string nomeEvento, DateTime dataInicio, DateTime datafim)
        {
            var resultado = await _evento.BuscarEventosPeloNomeouDataTrazendoUsuario(nomeEvento, dataInicio, datafim);
            try
            {
                if (resultado != null)
                    return Ok(resultado);
                else
                    return NotFound();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("{rm}")]
        public async Task<IActionResult> BuscarPeloRm(int rm)
        {
            var resultado = await _evento.BuscarPeloRm(rm);
            try
            {
                if(resultado != null)
                {
                    return Ok(resultado);
                }
                else
                {
                    return NotFound("Insira um RM válido.");
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
