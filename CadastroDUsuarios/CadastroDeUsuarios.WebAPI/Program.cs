
using CadastroDeUsuarios.WebAPI.Context;
using Microsoft.EntityFrameworkCore;
using CadastroDeUsuarios.Application.Interfaces;
using CadastroDeUsuarios.Application.Services;
using CadastroDeUsuarios.Application.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using CadastroDeUsuarios.Application.Auth;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;

namespace CadastroDeUsuarios.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<CadastroContext>
                    (op => op.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));


            builder.Services.AddScoped<IUsuarioService, UsuarioService>();
            builder.Services.AddScoped<TokenService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Autorização JWT (header) usando Bearer. \r\n\r\n Digite 'Bearer' [espaço] e o token em seguida.\r\n\r\nExemplo: \"Bearer c76n21m890edf2i9mci\"",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });


            });

            var key = Encoding.ASCII.GetBytes(Settings.Key);

            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(x => x
              .AllowAnyOrigin() // Permite todas as origens
              .AllowAnyMethod() // Permite todos os métodos
              .AllowAnyHeader()) // Permite todos os cabeçalhos
              .UseAuthentication();

            app.UseAuthorization();

            app.UseAuthentication();

            app.MapControllers();

            app.Run();


        }
    }
}
