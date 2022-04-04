using Core.Config;
using Core.Domain;
using Core.Infra.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add services to the container.


builder.Services.AddCors(options =>
{
    ///To fix issues with CORS, include the code below
    options.AddPolicy("Defaultc", builder =>
    {
        builder.WithOrigins("http://localhost:3000").WithMethods("PUT", "POST", "DELETE", "GET", "OPTIONS")
                .AllowAnyHeader()
                .AllowCredentials();
    });

});

//Adding dependency Injections
builder.Services.AddScoped<IBusStopRepository,StubBusStopRepository>();
builder.Services.AddScoped<IBusSchedulleRepository, StubBusSchedulleRepository>();
builder.Services.AddScoped<IBusRouteRepository, StubBusRouteRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//This line below references the json config File::::: Created by Marcelo
builder.Services.Configure<BusGatewayConfig>(builder.Configuration.GetSection("App:BusGateway"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();

