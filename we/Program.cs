using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
using ConsoleApp1;


namespace we
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<InterfaceCliente, RepositorioBancoDeDados>();
            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseFileServer();
            app.UseDefaultFiles();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")
                ),
                ContentTypeProvider = new FileExtensionContentTypeProvider
                {
                    Mappings = { [".properties"] = "application/x-msdownload" }
                }
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseCors(options =>
            {
                options.AllowAnyOrigin();
                options.AllowAnyMethod();
                options.AllowAnyHeader();
            });

            app.MapControllers();

            app.Run();
        }
    }
}