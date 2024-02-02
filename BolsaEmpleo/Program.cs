using BolsaEmpleoBusiness;
using BolsaEmpleoBusiness.Interfaces;
using BolsaEmpleoData;
using BolsaEmpleoData.Interfaces;
using BolsaEmpleoModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ICiudadanosData, CiudadanosData>();
builder.Services.AddTransient<ICiudadanosBusiness, CiudadanosBusiness>();
builder.Services.AddTransient<ITipoDoctoData, TipoDoctoData>();
builder.Services.AddTransient<ITipoDoctoBusiness, TipoDoctoBusiness>();
builder.Services.AddTransient<IVacanteData, VacanteData>();
builder.Services.AddTransient<IVacanteBusiness, VacanteBusiness>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("NuevaPolitica");

app.UseAuthorization();

app.MapControllers();

app.Run();