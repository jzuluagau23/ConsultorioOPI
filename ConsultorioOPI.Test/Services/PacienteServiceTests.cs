using AutoMapper;
using ConsultorioOPI.Domain.Dto;
using ConsultorioOPI.Logic.Services;
using ConsultorioOPI.Repository.Interfaces;
using ConsultorioOPI.Repository.Persistence.Models;
using Moq;
using Xunit;

public class PacienteServiceTests
{
    private readonly Mock<IPacienteRepository> _mockRepository;
    private readonly IMapper _mapper;
    private readonly PacienteService _service;

    public PacienteServiceTests()
    {
        _mockRepository = new Mock<IPacienteRepository>();

        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Paciente, PacienteDto>().ReverseMap();
        });
        _mapper = config.CreateMapper();

        _service = new PacienteService(_mockRepository.Object, _mapper);
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsPaciente_WhenExists()
    {
        _mockRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new Paciente { Id = 1, Nombre = "Juan" });

        var result = await _service.GetByIdAsync(1);

        Assert.NotNull(result);
        Assert.Equal("Juan", result.Nombre);
    }

    [Fact]
    public async Task GetAllAsync_ReturnsAllPacientes()
    {
        _mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<Paciente> {
                new Paciente { Id = 1, Nombre = "Juan" },
                new Paciente { Id = 2, Nombre = "Maria" }
            });

        var result = await _service.GetAllAsync();

        Assert.Equal(2, result.Count());
    }
}



