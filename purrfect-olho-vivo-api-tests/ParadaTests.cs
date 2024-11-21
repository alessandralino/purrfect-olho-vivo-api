using purrfect_olho_vivo_api.Controllers;
using purrfect_olho_vivo_api.Interfaces;
using purrfect_olho_vivo_api.ViewModels.Requests;
using purrfect_olho_vivo_api.ViewModels.Models;
using Moq;
using Microsoft.AspNetCore.Mvc;
using purrfect_olho_vivo_api.Domain;

namespace purrfect_olho_vivo_api_tests
{
    public class ParadaTests
    {
        [Fact]
        public async Task GetAllParada_ReturnsOkWithParadas() 
        {
            // Arrange
            var mockParadaService = new Mock<IParadaService>();

            // Lista simulada de paradas
            var paradaList = new List<Parada>
            {
                new Parada { Id = 1, Name = "Parada 1", Latitude = 1111, Longitude= 2222, Linhas = []},
                new Parada { Id = 2, Name = "Parada 2", Latitude = 3333, Longitude= 4444, Linhas = []}
            };

            // Criar um objeto PagedList<Parada> simulado
            var pagedParadaList = new PagedList<Parada>(paradaList, paradaList.Count, 1, 10);

            // Configurar o mock para retornar o PagedList como uma Task
            mockParadaService
                .Setup(service => service.GetAll(It.IsAny<ParadaGetRequest>()))
                .ReturnsAsync(pagedParadaList);

            var controller = new ParadaController(mockParadaService.Object);

            var request = new ParadaGetRequest
            {
                pageNumber = 1,
                pageSize = 10,                
            };

            // Act
            var result = await controller.GetAll(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);  
            var returnedParadas = Assert.IsAssignableFrom<PagedList<Parada>>(okResult.Value); 

            Assert.NotNull(returnedParadas);

            Assert.Equal(2, returnedParadas.Count);

            Assert.Equal(1, returnedParadas[0].Id);
            Assert.Equal("Parada 1", returnedParadas[0].Name);
            Assert.Equal(1111, returnedParadas[0].Latitude);
            Assert.Equal(2222, returnedParadas[0].Longitude);

            Assert.Equal(2, returnedParadas[1].Id);
            Assert.Equal("Parada 2", returnedParadas[1].Name);
            Assert.Equal(3333, returnedParadas[1].Latitude);
            Assert.Equal(4444, returnedParadas[1].Longitude);
        }

        [Fact]
        public async Task GetParadaById_ReturnsOkWithParadas()
        {
            //Arrenge
            var mockParadaService = new Mock<IParadaService>();

            var parada = new Parada
            { 
                Id = 1, Name = "Parada 1", Latitude = 1111, Longitude = 2222, Linhas = [] 
            };

            mockParadaService
                .Setup(service => service.GetParadaById(It.IsAny<long>()))
                .ReturnsAsync(parada);

            var controller = new ParadaController(mockParadaService.Object);

            long request = 1;

            //Act
            var result = await controller.GetParadaById(request);

            //Assert
            Assert.IsType<Parada>(result.Value);
            Assert.NotNull(result.Value);
            Assert.Equal(1, result?.Value?.Id);
            Assert.Equal("Parada 1", result?.Value?.Name);
        }
    }
}