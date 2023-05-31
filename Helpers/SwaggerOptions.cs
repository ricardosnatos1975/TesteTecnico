using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TesteTecnico.Helpers
{
    public static class SwaggerOptions
    {
        public static void Configure(SwaggerGenOptions options)
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Teste Tecnico",
                Description = "Chamada de Produto e Categoria",
            });
        }
    }
}
