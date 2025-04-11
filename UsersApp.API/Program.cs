using Scalar.AspNetCore;
using UsersApp.Infra.Data.MongoDB.Extensions;
using UsersApp.Infra.Data.SqlServer.Extensions;
using UsersApp.Infra.Security.Extensions;
using UsersApp.Domain.Extensions;
using UsersApp.Application.Extensions;
using UsersApp.API.Middlewares;
using UsersApp.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

#region Documentação da API

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

builder.Services.AddAppServices();
builder.Services.AddDomainServices();
builder.Services.AddEntityFramework(builder.Configuration);
builder.Services.AddMongoDBExtension();
builder.Services.AddJwtSecurity(builder.Configuration);
//builder.AddSeriLogConfigExtension();

var app = builder.Build();

app.MapOpenApi();
app.UseSwagger();
app.UseSwaggerUI();
app.MapScalarApiReference(options =>
{
    options
    .WithTitle("API de usuários - COTI Informática")
    .WithTheme(ScalarTheme.BluePlanet)
    .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
});

//app.UseSeriLogConfigExtension();

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
