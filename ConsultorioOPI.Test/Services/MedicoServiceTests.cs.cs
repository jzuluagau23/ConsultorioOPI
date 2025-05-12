using AutoMapper;
using ConsultorioOPI.Domain.Dto;
using ConsultorioOPI.Logic.Maping;
using ConsultorioOPI.Logic.Services;
using ConsultorioOPI.Repository.Interfaces;
using ConsultorioOPI.Repository.Persistence.Models;
using Moq;
using Xunit;

namespace ConsultorioOPI.Tests.Unit
{
    public class MedicoServiceTests
    {
        private readonly Mock<IMedicoRepository> _mockRepository;
        private readonly IMapper _mapper;
        private readonly MedicoService _service;

        public MedicoServiceTests()
        {
            _mockRepository = new Mock<IMedicoRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = config.CreateMapper();
            _service = new MedicoService(_mockRepository.Object, _mapper);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsMedicoDto_WhenMedicoExists()
        {
            var medico = new Medico { Id = 1, Nombre = "Dra. García", Especialidad = "Cardiología" };

            _mockRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(medico);

            var result = await _service.GetByIdAsync(1);

            Assert.NotNull(result);
            Assert.IsType<MedicoDto>(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Dra. García", result.Nombre);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsNull_WhenMedicoDoesNotExist()
        {
            _mockRepository.Setup(r => r.GetByIdAsync(999)).ReturnsAsync((Medico?)null);

            var result = await _service.GetByIdAsync(999);

            Assert.Null(result);
        }
    }
}
