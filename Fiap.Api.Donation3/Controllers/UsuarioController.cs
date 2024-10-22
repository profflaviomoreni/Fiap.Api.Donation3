using AutoMapper;
using Fiap.Api.Donation3.Models;
using Fiap.Api.Donation3.Repository.Interface;
using Fiap.Api.Donation3.Services;
using Fiap.Api.Donation3.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.Donation3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioRepository _usuarioRepository;

        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IList<UsuarioModel>> Get()
        {
            var usuarios = _usuarioRepository.FindAll();

            if (usuarios != null && usuarios.Count > 0)
            {
                return Ok(usuarios);
            }
            else
            {
                return NoContent();
            }

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
        public async Task<ActionResult<LoginResponseVM>> Login([FromBody] LoginRequestVM loginRequestVM)
        {

            if (ModelState.IsValid)
            {
                var usuarioModel = await _usuarioRepository
                        .FindByEmailAndSenha(loginRequestVM.EmailUsuario, loginRequestVM.Senha);


                if (usuarioModel != null)
                {

                    var tokenJWT = AuthenticationService.GetToken(usuarioModel);

                    var loginResponseVM = _mapper.Map<LoginResponseVM>(usuarioModel);
                    loginResponseVM.Token = tokenJWT;

                    //var loginResponseVM = new LoginResponseVM();
                    //loginResponseVM.Token = tokenJWT;
                    //loginResponseVM.EmailUsuario = usuarioModel.EmailUsuario;
                    //loginResponseVM.NomeUsuario = usuarioModel.NomeUsuario;
                    //loginResponseVM.Regra = usuarioModel.Regra;
                    //loginResponseVM.UsuarioId = usuarioModel.UsuarioId;


                    return Ok(loginResponseVM);
                }
                else
                {
                    return NotFound();
                }
            } else
            {
                return BadRequest(ModelState);
            }

        }


    }
}
