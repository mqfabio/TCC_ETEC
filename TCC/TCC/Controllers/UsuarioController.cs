using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using TCC.DTO;
using TCC.Models;
using TCC.Services;

namespace TCC.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario _usuario;
        public UsuarioController(IUsuario usuario)
        {
            _usuario = usuario;
        }

       

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginDoUsuarioDTO>> AutenticaçãoDoUsuario([FromBody] Usuario model)
        {
            var usuario = await _usuario.PegarPeloEmailSenha(model.Email, model.Senha);

            if(usuario == null)
                return BadRequest("Usuário ou senha inválidos");

            var token = TokenService.GenerateToken(usuario);
            usuario.Senha = "";
            return new LoginDoUsuarioDTO
            {
                Nome = usuario.NomeUsuario,
                Token = token
            };
        }



        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Cadastrar(Usuario servidor)
        {
            var resultado = await _usuario.Cadastrar(servidor);
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
        public async Task<IActionResult> Buscartodos()
        {
            var resultado = await _usuario.BuscarTodos();
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

        

        [HttpGet("{email}")]
        public async Task<IActionResult> PegarPeloEmail(string email)
        {
            var resultado = await _usuario.PegarPeloEmail(email);
            try
            {
                if (resultado != null)
                {
                    return Ok(resultado);
                }

                else
                {
                    return BadRequest("Insira um email valido");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode());
            }
            throw new NotImplementedException();
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Alterar([Required][FromBody] Usuario usuario)
        {
            var resultado = await _usuario.Alterar(usuario);

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


