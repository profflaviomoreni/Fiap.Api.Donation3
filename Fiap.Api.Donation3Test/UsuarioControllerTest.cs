using Fiap.Api.Donation3.Controllers;
using Fiap.Api.Donation3.Models;
using Fiap.Api.Donation3.Repository.Interface;
using Fiap.Api.Donation3.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Fiap.Api.Donation3Test
{
    public class UsuarioControllerTest : BaseTest
    {
        private readonly Mock<IUsuarioRepository> _mockUsuarioRepository;

        public UsuarioControllerTest()
        {
            _mockUsuarioRepository = new Mock<IUsuarioRepository>();
        }

        [Fact]
        public async Task GetUsuarioResultOkWithUsuarios()
        {
            // Arrange
            var usuarios = new List<UsuarioModel> {
                new UsuarioModel { UsuarioId = 1, NomeUsuario = "Usuario 1" },
                new UsuarioModel { UsuarioId = 2, NomeUsuario = "Usuario 2" }
            };

            _mockUsuarioRepository.Setup(r => r.FindAllAsync()).ReturnsAsync(usuarios);

            var controller = new UsuarioController(_mockUsuarioRepository.Object, _mapper);

            // Act
            var result = await controller.Get();

            // Assert
            var resultType = Assert.IsType<OkObjectResult>(result.Result);
            var resultValue = Assert.IsType<List<UsuarioResponseViewModel>>(resultType.Value);

            Assert.Equal(2, resultValue.Count);
            Assert.Equal("Usuario 1", resultValue[0].NomeUsuario);
            Assert.Equal("Usuario 2", resultValue[1].NomeUsuario);
        }


        [Fact]
        public async Task GetUsuarioResultOkWith3Usuarios()
        {
            // Arrange
            var usuarios = new List<UsuarioModel> {
                new UsuarioModel { UsuarioId = 1, NomeUsuario = "Usuario 1" },
                new UsuarioModel { UsuarioId = 2, NomeUsuario = "Usuario 2" },
                new UsuarioModel { UsuarioId = 3, NomeUsuario = "Usuario 3" }
            };

            _mockUsuarioRepository.Setup(r => r.FindAllAsync()).ReturnsAsync(usuarios);

            var controller = new UsuarioController(_mockUsuarioRepository.Object, _mapper);

            // Act
            var result = await controller.Get();

            // Assert
            var resultType = Assert.IsType<OkObjectResult>(result.Result);
            var resultValue = Assert.IsType<List<UsuarioResponseViewModel>>(resultType.Value);

            Assert.Equal(3, resultValue.Count);
        }

        [Fact]
        public async Task GetUsuarioResultNoContent()
        {
            // Arrange
            var usuarios = new List<UsuarioModel>();

            _mockUsuarioRepository.Setup(r => r.FindAllAsync()).ReturnsAsync(usuarios);

            var controller = new UsuarioController(_mockUsuarioRepository.Object, _mapper);

            // Act
            var result = await controller.Get();

            // Assert
            Assert.IsType<NoContentResult>(result.Result);
        }
    }
}
