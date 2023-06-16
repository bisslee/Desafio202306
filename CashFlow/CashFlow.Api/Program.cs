using CashFlow.Infrastructure.Data.Contexts;
using CashFlow.Service.Interface;
using CashFlow.Service;
using CashFlow.Infrastructure.Repositories.Interfaces;
using CashFlow.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using CashFlow.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CashFlowDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddAutoMapper(typeof(TransactionProfile));
builder.Services.AddScoped<IBalanceService, BalanceService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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