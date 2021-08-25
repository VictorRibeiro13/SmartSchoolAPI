using Microsoft.Extensions.DependencyInjection;
using SmartSchool.API.Common.Interfaces;
using SmartSchool.API.Repositories;
using System;
using System.IO;
using System.Reflection;

namespace SmartSchool.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection services)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();

            AddSwagger(services);
            services.AddHttpClient();
            return services;
        }

        private static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options => {
                options.SwaggerDoc(
                    "SmartSchoolApi",
                    new Microsoft.OpenApi.Models.OpenApiInfo() {
                        Title = "Smart School API",
                        Version = "1.0"
                    }
                );

                string xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string fullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

                options.IncludeXmlComments(fullPath);
            });
        }
    }
}
