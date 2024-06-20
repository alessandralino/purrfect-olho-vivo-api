using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using NuGet.ContentModel;
using purrfect_olho_vivo_api.Controllers;
using purrfect_olho_vivo_api.Interfaces;
using purrfect_olho_vivo_api.ViewModels.Models;
using System.Linq;


namespace purrfect_olho_vivo_api.purrfectOlhoVivoApi.Test.Controllers
{
    public class ParadaControllerTest
    {
        private readonly Mock<IParadaService> _paradaServiceMock;
        private readonly ParadaController _controller;

        public ParadaControllerTest()
        {
            _paradaServiceMock = new Mock<IParadaService>();
            _controller = new ParadaController(_paradaServiceMock.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsOkResult_WithListOfParadas()
        {
            // Arrange
            var paradas = new List<Parada> { new Parada { Id = 1 }, new Parada { Id = 2 } };
            _paradaServiceMock.Setup(service => service.GetAll()).ReturnsAsync(paradas);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<Parada>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public async Task Delete_ReturnsNoContent_WhenSuccessful()
        {
            // Arrange
            _paradaServiceMock.Setup(service => service.Delete(1)).ReturnsAsync(true);

            // Act
            var result = await _controller.Delete(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
