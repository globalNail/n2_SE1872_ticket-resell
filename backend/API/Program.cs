﻿using API.Injection;
using Repository.Models;

var builder = WebApplication.CreateBuilder(args);

//// Lấy đường dẫn tương đối đến file JSON từ thư mục gốc của project
//var pathToKey = Path.Combine(Directory.GetCurrentDirectory(), "TicketResell.json");

//// Khởi tạo Firebase Admin SDK
//FirebaseApp.Create(new AppOptions()
//{
//    Credential = GoogleCredential.FromFile(pathToKey)
//});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ServicesInjection(builder.Configuration);
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

app.UseStaticFiles();

app.Run();
