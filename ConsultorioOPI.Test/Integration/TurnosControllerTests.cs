using ConsultorioOPI.Domain.Dto;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using Xunit;

namespace ConsultorioOPI.Test.IntegrationTests
{
    public class TurnosControllerTests : IntegrationTestBase
    {
        public TurnosControllerTests(WebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task Post_Turno_CreatesSuccessfully()
        {
            var turno = new TurnoDto
            {
                PacienteId = 1,
                MedicoId = 1,
                FechaHora = DateTime.UtcNow.AddDays(1),
                EstadoId = 1
            };

            var response = await _client.PostAsJsonAsync("/api/Turnos", turno);

            response.EnsureSuccessStatusCode();
            var created = await response.Content.ReadFromJsonAsync<TurnoDto>();
            created.Should().NotBeNull();
            created!.Id.Should().BeGreaterThan(0);
        }

        [Fact]
        public async Task GetAll_ReturnsOk()
        {
            Authenticate();
            var response = await _client.GetAsync("/api/Turnos");

            response.EnsureSuccessStatusCode();
            var turnos = await response.Content.ReadFromJsonAsync<List<TurnoDto>>();
            turnos.Should().NotBeNull();
        }

        [Fact]
        public async Task Put_Turno_UpdatesSuccessfully()
        {
           
            var turno = new TurnoDto
            {
                PacienteId = 1,
                MedicoId = 1,
                FechaHora = DateTime.UtcNow.AddDays(1),
                EstadoId = 1
            };

            var postResponse = await _client.PostAsJsonAsync("/api/Turnos", turno);
            var created = await postResponse.Content.ReadFromJsonAsync<TurnoDto>();

            
            created!.FechaHora = created.FechaHora.AddDays(1);
            Authenticate(); 

            var putResponse = await _client.PutAsJsonAsync($"/api/Turnos/{created.Id}", created);
            putResponse.EnsureSuccessStatusCode();

            var updated = await putResponse.Content.ReadFromJsonAsync<TurnoDto>();
            updated!.FechaHora.Date.Should().Be(created.FechaHora.Date);
        }

        [Fact]
        public async Task Delete_Turno_WorksCorrectly()
        {
            // Crear primero
            var turno = new TurnoDto
            {
                PacienteId = 1,
                MedicoId = 1,
                FechaHora = DateTime.UtcNow.AddDays(1),
                EstadoId = 1
            };

            var postResponse = await _client.PostAsJsonAsync("/api/Turnos", turno);
            var created = await postResponse.Content.ReadFromJsonAsync<TurnoDto>();

            // Eliminar
            var deleteResponse = await _client.DeleteAsync($"/api/Turnos/{created!.Id}");
            deleteResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
        }
    }
}
