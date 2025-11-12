using FaturamentoService.Middleware;
using FaturamentoService.Data;
using FaturamentoService.Interfaces;
using FaturamentoService.Repository;
using FaturamentoService.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<FaturamentoServiceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Repositórios
builder.Services.AddScoped<INotaFiscalRepository, NotaFiscalRepository>();


// Services
builder.Services.AddScoped<INotaFiscalService, NotaFiscalService>();

builder.Services.AddHttpClient<INotaFiscalService, NotaFiscalService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTudo", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlerMiddleware>();

// Configure the HTTP request pipeline.

// Configure o middleware do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("PermitirTudo");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

