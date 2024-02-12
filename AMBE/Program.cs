
using AMBE.Data;
using AMBE.Services;
using Microsoft.EntityFrameworkCore;

namespace AMBE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<TransportedbContext>(o =>
            {
                o.UseMySql(builder.Configuration.GetConnectionString("ConexionMySql"), ServerVersion.Parse("8.0.32-mysql"));
            });

            builder.Services.AddScoped<IServicioUsuario, ServicioUsuario>();
            builder.Services.AddScoped<IServicioBitacora,ServicioBitacora>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
