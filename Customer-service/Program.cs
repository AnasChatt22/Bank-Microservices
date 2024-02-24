using AutoMapper;
using customer_service;
using customer_service.Data;
using customer_service.Interfaces;
using customer_service.Repositories;
using Microsoft.EntityFrameworkCore;
using Steeltoe.Discovery.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddHttpContextAccessor();
var link = builder.Configuration.GetSection("ServiceUrls").GetSection("AccountApi").Value;
builder.Services.AddHttpClient("Account", u => u.BaseAddress = new Uri(link));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDiscoveryClient();
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
