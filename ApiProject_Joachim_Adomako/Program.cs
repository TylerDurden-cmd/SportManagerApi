
using ApiProject_Joachim_Adomako.Data;
using ApiProject_Joachim_Adomako.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace ApiProject_Joachim_Adomako
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
                    options.JsonSerializerOptions.WriteIndented = true;
                });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var db = builder.Configuration.GetValue<bool>("db");
            if (db)
            {
                builder.Services.AddScoped<ITeamService, TeamServiceDb>();
                builder.Services.AddScoped<IPlayerService, PlayerServiceDb>();
                builder.Services.AddScoped<IMatchService, MatchServiceDb>();

                builder.Services.AddDbContext<SportDbContext>(options =>
                {
                    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                    var serverVersion = ServerVersion.AutoDetect(connectionString);

                    options.UseMySql(connectionString, serverVersion);
                });
            }
            else
            {
                builder.Services.AddScoped<ITeamService, TeamService>();
                builder.Services.AddScoped<IPlayerService, PlayerService>();
                builder.Services.AddScoped<IMatchService, MatchService>();
            }

            

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
