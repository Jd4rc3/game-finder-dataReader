using Application;
using Application.Settings;
using Domain.UseCases;
using Infraestructure.Context;
using Infraestructure.DrivenAdapters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.AddEnvironmentVariables();

var settings = builder.Configuration.GetRequiredSection(nameof(MongoConnection)).Get<MongoConnection>();

builder.Services.AddSingleton<IContext>(_ => new Context(settings.ConnectionString, settings.DatabaseName));
builder.Services.AddTransient<IParameterRepository, MongoAdapter>();
builder.Services.AddTransient<CreateParameterUseCase>();
builder.Services.AddTransient<ReadParameterUseCase>();
builder.Services.AddTransient<UpdateParameterValuesUseCase>();
builder.Services.AddTransient<UpdateParameterNameUseCase>();
builder.Services.AddMvc(options => { options.Filters.Add(typeof(ExceptionFilter)); });

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