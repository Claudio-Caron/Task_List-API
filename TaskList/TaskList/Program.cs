using Microsoft.EntityFrameworkCore;
using TaskList.Data.Base;
using TaskList.Data.Model;
using TaskList.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TaskContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<DAL<Tarefa>>();
builder.Services.AddScoped<Tarefa>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.AddEndpointsTask();

app.Run();
