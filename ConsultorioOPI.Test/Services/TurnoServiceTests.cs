using AutoMapper;
using ConsultorioOPI.Domain.Dto;
using ConsultorioOPI.Logic.Services;
using ConsultorioOPI.Repository.Interfaces;
using ConsultorioOPI.Repository.Persistence.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ConsultorioOPI.Test.Services
{
    public class TurnoServiceTests
    {
        private readonly Mock<ITurnoRepository> _mockRepositorysitory;
        private readonly IMapper _mapper;
        private readonly TurnoService _service;

        public TurnoServiceTests()
        {
            _mockRepositorysitory = new Mock<ITurnoRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Turno, TurnoDto>().ReverseMap();
            });
            _mapper = config.CreateMapper();

            _service = new TurnoService(_mockRepositorysitory.Object, _mapper);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsTurno_WhenExists()
        {
            _mockRepositorysitory.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new Turno { Id = 1, PacienteId = 5 });

            var result = await _service.GetByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllTurnos()
        {
            _mockRepositorysitory.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<Turno> {
                new Turno { Id = 1 },
                new Turno { Id = 2 }
            });

            var result = await _service.GetAllAsync();

            Assert.Equal(2, result.Count());
        }
    }
}
