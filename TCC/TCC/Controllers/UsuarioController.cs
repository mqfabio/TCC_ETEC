using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using TCC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using TCC.Data;
using System.Linq;
using TCC.Services;
using TCC.DTO;
using System.ComponentModel.DataAnnotations;

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
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserAuthenticationResponseDTO>> Authenticate([FromBody] Usuario model)
        {
            var usuario = await _usuario.PegarPeloNome(model.NomeUsuario, model.Senha);

            if(usuario == null)
                return BadRequest("Usuário ou senha inválidos");

            var token = TokenService.GenerateToken(usuario);
            usuario.Senha = "";
            return new UserAuthenticationResponseDTO
            {
                Nome = usuario.NomeUsuario,
                Token = token
            };

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
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
        [AllowAnonymous]
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

        [HttpGet("{nome}")]
        public async Task<IActionResult> PegarPeloNomeESenha(string nome, string senha)
        {
            var resultado = await _usuario.PegarPeloNome(nome, senha);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> AlterarAsync([Required][FromBody] Usuario usuario)
        {
            var resultado = await _usuario.AlterarAsync(usuario);

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
                throw new NotImplementedException();
            }
           
        }
    }
   
}


