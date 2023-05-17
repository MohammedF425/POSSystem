using Microsoft.EntityFrameworkCore;
using POS.Core.Domain.RepositoryContracts;
using POS.Core.ServiceContracts;
using POS.Core.Services;
using POS.Infrastructure.DatabaseContext;
using POS.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<IProductsService, ProductsService>();

builder.Services.AddScoped<IInventoriesRepository, InventoryRepository>();
builder.Services.AddScoped<IInventoriesService, InventoriesService>();

builder.Services.AddScoped<ICustomerPurchasePerProductRepository, CustomerPurchasePerProductRepository>();
builder.Services.AddScoped<IReceiptRepository, ReceiptRepository>();
builder.Services.AddScoped<ICustomerPurchasesService, CustomerPurchasesService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

