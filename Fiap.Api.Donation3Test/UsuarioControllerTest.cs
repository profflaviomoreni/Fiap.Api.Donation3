using AutoMapper;
using Fiap.Api.Donation3.Controllers;
using Fiap.Api.Donation3.Models;
using Fiap.Api.Donation3.Repository.Interface;
using Fiap.Api.Donation3.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Fiap.Api.Donation3Test
{
    public class UsuarioControllerTest
    {

        private readonly Mock<IUsuarioRepository> _mockUsuarioRepository;

        private readonly Mock<IMapper> _mockMapper;

        private readonly IMapper _mapper;


        public UsuarioControllerTest()
        {
            _mockUsuarioRepository = new Mock<IUsuarioRepository>();      
            
            _mockMapper = new Mock<IMapper>();


            var configMapper = new MapperConfiguration(m => {
                m.AllowNullDestinationValues = true;
                m.AllowNullCollections = true;

                m.CreateMap<UsuarioModel, LoginRequestVM>();
                m.CreateMap<LoginRequestVM, UsuarioModel>();

                m.CreateMap<UsuarioModel, LoginResponseVM>();
                m.CreateMap<LoginResponseVM, UsuarioModel>();
            });

            _mapper = configMapper.CreateMapper();
        }


        [Fact]
        //public async Task GetUsuarioResultOkWithUsuarios()
        public void GetUsuarioResultOkWithUsuarios()
        {
            var usuarios = new List<UsuarioModel>() {
                new UsuarioModel()
            };

            _mockUsuarioRepository.Setup( r => r.FindAll() ).Returns( usuarios );

            var controller = new UsuarioController(_mockUsuarioRepository.Object, _mapper);

            var result = controller.Get();

            var resultType = Assert.IsType<OkObjectResult>(result.Result);
            var resultValue = Assert.IsType<List<UsuarioModel>>(resultType.Value);

            Assert.Single(resultValue);
            Assert.Equal(1, resultValue.Count);

        }

        [Fact]
        public void GetUsuarioResultOkWith3Usuarios()
        {
            var usuarios = new List<UsuarioModel>() {
                new UsuarioModel(),
                new UsuarioModel(),
                new UsuarioModel()
            };

            _mockUsuarioRepository.Setup(r => r.FindAll()).Returns(usuarios);

            var controller = new UsuarioController(_mockUsuarioRepository.Object, _mockMapper.Object);

            var result = controller.Get();

            var resultType = Assert.IsType<OkObjectResult>(result.Result);
            var resultValue = Assert.IsType<List<UsuarioModel>>(resultType.Value);

            Assert.Equal(3, resultValue.Count);

        }


        [Fact]
        public void GetUsuarioResultNoContent()
        {
            var usuarios = new List<UsuarioModel>();

            _mockUsuarioRepository.Setup(r => r.FindAll()).Returns(usuarios);

            var controller = new UsuarioController(_mockUsuarioRepository.Object, _mockMapper.Object);

            var result = controller.Get();

            Assert.IsType<NoContentResult>(result.Result);

        }

    }
}
