using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using TCC.Models;

namespace TCC.Controllers
{

    [ApiController]
    [Route("servidor")]
    public class ServidorController : ControllerBase
    {
        private readonly IServidor _servidor;
        public ServidorController(IServidor servidor)
        {
            _servidor = servidor;
        }

        //[HttpPut]
        //public async Task<IActionResult> AlterarAsync([Required][FromBody] Servidor servidor)
        //{
        //    var resultado = await _servidor.AlterarAsync(servidor);
        //    try
        //    {
        //        if (resultado)
        //        {
        //            return StatusCode(HttpStatusCode.Created.GetHashCode());
        //        }
        //        else
        //        {
        //            return StatusCode(HttpStatusCode.InternalServerError.GetHashCode());
        //        }
        //    }
        //    catch(Exception e)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> CadastrarAsync(Servidor servidor)
        {
            var resultado = await _servidor.CadastrarAsync(servidor);
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

        [HttpGet]
        public async Task<IActionResult> BuscartodosASync()
        {
            var resultado = await _servidor.BuscarTodosAsync();
            try
            {
                if(resultado != null)
                {
                    return Ok(resultado);
                }

                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
   
}


