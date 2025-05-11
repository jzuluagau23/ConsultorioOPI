using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using Xunit;
using ConsultorioOPI.Api;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ConsultorioOPI.Repository.Persistence;

/// <summary>
/// Configuraciones para las pruebas de integración
/// </summary>
public class IntegrationTestBase : IClassFixture<WebApplicationFactory<Program>>
{
    protected readonly HttpClient _client;

    /// <summary>
    /// Constructor IntegrationTestBase
    /// </summary>
    /// <param name="factory"></param>
    public IntegrationTestBase(WebApplicationFactory<Program> factory)
    {
        _client = factory.WithWebHostBuilder(builder =>
        {
            //accede a las configuraciones de program.cs para modificarlas antes de ejecutar las pruebas
            builder.ConfigureServices(services =>
            {
                //Elimina las configuraciones del contexto real para que no se use al momento de ejecutar las pruebas
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ConsultorioOPIContext>));
                if (descriptor != null)
                    services.Remove(descriptor);

                //Gerera un nuevo contexto para usarse en las pruebas de integración
                services.AddDbContext<ConsultorioOPIContext>(options =>
                {
                    options.UseInMemoryDatabase("TestDb");
                });
            });
        }).CreateClient();
    }

    /// <summary>
    /// Genera un token simulado
    /// </summary>
    /// <returns>Token JWT</returns>
    protected string GetJwtToken()
    {
        // Simula un JWT válido generado con el Api api/Auth/login-without-user
        return "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYWRtaW4iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbmlzdHJhZG9yIiwiZXhwIjoxNzQ2OTczOTcwLCJpc3MiOiJDb25zdWx0b3Jpb09QSSIsImF1ZCI6IkNvbnN1bHRvcmlvT1BJVXN1YXJpb3MifQ.FAn6UHH5ZWm_0QhA4Lv3mwFe8_9ToVcbpX2dZpCitDM";
    }

    /// <summary>
    /// Envia el token de autorización para poder consumir las api´s
    /// </summary>
    protected void Authenticate()
    {
        //encabezado HTTP Authorization para enviar el token generado
        _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", GetJwtToken());
    }
}
