using Commerce.Api.ServiceRegistrations;
using Commerce.Data.DataContext;
using FluentValidation.AspNetCore;
using MinimalAPIs.ServiceRegistrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFluentValidation();

builder.Services.AddSingleton<ICommerceContext, CommerceContext>();
builder.Services.AddCustomerRegistrations();
builder.Services.AddOrderRegistrations();
builder.Services.AddProductRegistrations();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();