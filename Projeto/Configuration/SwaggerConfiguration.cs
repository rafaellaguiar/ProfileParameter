using Microsoft.OpenApi.Models;

namespace Projeto.Configuration
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.EnableAnnotations();

                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Profile - Api",
                    Description = "Api Profiles",
                    Version = "v1"
                });
            });
        }
    }
}
