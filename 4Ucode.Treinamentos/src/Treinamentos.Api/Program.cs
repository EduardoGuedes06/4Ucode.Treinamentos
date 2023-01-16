using Data.context;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Treinamentos.Api.Config;
using Treinamentos.Api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "4Ucode Treinamento.API",
        Description = "A simple example ASP.NET Core Web API",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Eduardo guedes",
            Email = "eduardoguedeslibras@gmail.com",
            Url = new Uri("https://www.zedotech.com"),
        },
        License = new OpenApiLicense
        {
            Name = "Use under LICX",
            Url = new Uri("https://example.com/license"),
        }
    });
});
builder.Services.AddCors();

builder.Services.AddIdentityConfig(builder.Configuration);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql("server=mysql-banco-api.mysql.database.azure.com;initial catalog=TreinamentosDB;uid=MysqlRoot;pwd=Mudar#123",
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.0-mysql")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddDbContext<MeuDbContext>(options =>
{
    options.UseMySql("server=mysql-banco-api.mysql.database.azure.com;initial catalog=TreinamentosDB;uid=MysqlRoot;pwd=Mudar#123",
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.0-mysql")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.ResolveDependencies();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials());

app.MapControllers();

app.Run();
