using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Treinamentos.Api.Config;
using Treinamentos.Api.Data;

var builder = WebApplication.CreateBuilder(args);

//Config:

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

builder.Services.AddIdentityConfig(builder.Configuration);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql("server=mysql-banco-api.mysql.database.azure.com;initial catalog=TreinamentosDB;uid=MysqlRoot;pwd=Mudar#123",
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.0-mysql")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddApiConfig();
builder.Services.AddSwaggerConfig();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.ResolveDependencies();

//Build App:

var app = builder.Build();
var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

app.UseApiConfig(app.Environment);
app.UseSwaggerConfig(apiVersionDescriptionProvider);

//app.UseAuthorization();
//app.UseAuthentication();
//app.UseHttpsRedirection();
//app.MapControllers();
//app.UseDeveloperExceptionPage();

app.Run();
