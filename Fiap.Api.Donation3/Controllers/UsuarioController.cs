using Fiap.Api.Donation3.Models;
using Fiap.Api.Donation3.Repository.Interface;
using Fiap.Api.Donation3.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.Donation3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }


        [HttpPost]
        public ActionResult<UsuarioModel> Post([FromBody] UsuarioModel usuarioModel)
        {
            if (ModelState.IsValid)
            {
                var usuarioId = _usuarioRepository.Insert(usuarioModel);
                usuarioModel.UsuarioId = usuarioId;
                return Ok(usuarioModel);
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<dynamic>> Login([FromBody] UsuarioModel usuarioModel)
        {

            var usuarioRetorno = await _usuarioRepository.FindByEmailAndSenha(usuarioModel.EmailUsuario, usuarioModel.Senha);

            if (usuarioRetorno != null )
            {
                usuarioRetorno.Senha = string.Empty;

                var tokenJWT = AuthenticationService.GetToken(usuarioRetorno);

                var retorno = new
                {
                    usuario = usuarioRetorno,
                    token = tokenJWT
                };

                return Ok(retorno);
            } else
            {
                return NotFound();
            }

        }


    }
}
