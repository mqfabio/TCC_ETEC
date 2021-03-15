using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using TCC.Models;

namespace TCC.Controllers
{

    [ApiController]
    [Route("Usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario _usuario;
        public UsuarioController(IUsuario usuario)
        {
            _usuario = usuario;
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
        public async Task<IActionResult> CadastrarAsync(Usuario servidor)
        {
            var resultado = await _usuario.CadastrarAsync(servidor);
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
            var resultado = await _usuario.BuscarTodosAsync();
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


