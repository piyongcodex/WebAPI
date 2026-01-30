using CQRSpattern.Contracts;
using CQRSpattern.Data;
using CQRSpattern.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inject Repo
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

//Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseMySql(
    builder.Configuration.GetConnectionString("DefaultConnection"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection")))
);

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
