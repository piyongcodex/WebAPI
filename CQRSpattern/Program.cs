using CQRSpattern.API.Middlewares;
using CQRSpattern.Application.Behaviors;
using CQRSpattern.Infrastructure;
using FluentValidation;
using MediatR;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var presentationAssembly = typeof(CQRSpattern.Presentation.AssemblyReference).Assembly;
var applicationAssembly = typeof(CQRSpattern.Application.AssemblyReference).Assembly;


builder.Services.AddControllers().AddApplicationPart(presentationAssembly);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//register validators
builder.Services.AddValidatorsFromAssembly(applicationAssembly);

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

//Inject Repo
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(applicationAssembly);
});

//Logging
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseExceptionHandler();

app.UseAuthorization();

app.MapControllers();

app.Run();
