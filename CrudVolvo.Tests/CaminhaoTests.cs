using CrudVolvo.Controllers;
using CrudVolvo.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using Volvo.Data;
using Xunit;

namespace CrudVolvo.Tests
{
    public class CaminhaoTests
    {
        private CaminhaoService caminhaoService { get; set; }
        public CaminhaoTests()
        {
            var options = new DbContextOptionsBuilder<VolvoDBContext>()
                 .UseInMemoryDatabase(databaseName: "VolvoDatabase")
                 .Options;
            VolvoDBContext context = new VolvoDBContext(options);
            caminhaoService = new CaminhaoService(context);
        }

        [Fact]
        public void Adicionar()
        {
            var result = caminhaoService.Adicionar(new Caminhao { Placa = "ABC-1234", Modelo = "TH", AnoFabricacao = "2014", AnoModelo = "2015"});
            Assert.True(result);
        }

        [Fact]
        public void Editar()
        {
            var result = caminhaoService.Editar(new Caminhao { Id = 1, Placa = "ABC-1234", Modelo = "TH", AnoFabricacao = "2014", AnoModelo = "2015" });
            Assert.False(result);
        }

        [Fact]
        public void Editar_CaminhaoNaoExistente()
        {
            var result = caminhaoService.Editar(new Caminhao { Id = 10, Placa = "ABC-1234", Modelo = "TH", AnoFabricacao = "2014", AnoModelo = "2015" });
            Assert.False(result);
        }

        [Fact]
        public void GetAll()
        {
            var result = caminhaoService.GetAll();
            Assert.True(result is not null);
        }

        [Fact]
        public void FindByID_IdInexistente()
        {
            var result = caminhaoService.FindById(100);
            Assert.True(result is null);
        }

        [Fact]
        public void Remover_UtilizandoId()
        {
            var result = caminhaoService.Remover(1);
            Assert.True(result);
        }

    }
}