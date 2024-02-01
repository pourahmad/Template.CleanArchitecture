using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Template.CleanArchitecture.Application;
using Template.CleanArchitecture.Infrastructure;
using Template.CleanArchitecture.Persistence;

namespace Template.CleanArchitecture.Api
{
    public static class StartupHelperExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            AddSwagger(builder.Services);

            builder.Services.AddapplicationServieces();
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddInfrastructureServices(builder.Configuration);


            //builder.Services.AddHttpContextAccessor();

            builder.Services.AddControllers()
                .AddNewtonsoftJson(setupAction =>
                {
                    setupAction.SerializerSettings.ContractResolver =
                        new CamelCasePropertyNamesContractResolver();
                });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            builder.Services.AddCors();

            return builder.Build();

        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clean Architecture API");
                });
            }
            else
            {
                app.UseExceptionHandler(exceptionGenerate =>
                {
                    exceptionGenerate.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected fault happened.");
                    });
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //    app.UseAuthentication();

            //    app.UseCustomExceptionHandler();

            app.UseCors("AllowAll");


            //app.UseCorsAccessControllMiddleware();

            //    app.UseAuthorization();

            app.MapControllers();

            return app;

        }

        private static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {


                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Clean Architecture API",

                });

                //c.OperationFilter<FileResultContentTypeOperationFilter>();
            });
        }

        //public static async Task ResetDatabaseAsync(this WebApplication app)
        //{
        //    using var scope = app.Services.CreateScope();
        //    try
        //    {
        //        var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
        //        if (context != null)
        //        {
        //            await context.Database.EnsureDeletedAsync();
        //            await context.Database.MigrateAsync();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        var logger = scope.ServiceProvider.GetRequiredService<ILogger>();
        //        logger.LogError(ex, "An error occurred while migrating the database.");
        //    }
        //}
    }
}
