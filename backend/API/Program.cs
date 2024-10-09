using Repository.Interfaces;
using Repository.Models;
using Repository.Repositories;
using Service;
using Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ITicketService, TicketServices>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Swp391ticketResellPlatformContext>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy  =>
        {
            policy.WithOrigins("http://localhost:3910")
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowReactApp");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
