using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TaskManagementSystem.BusinessLogicLayer;
using TaskManagementSystem.DataAccessLayer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddFluentValidation().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationContext>(opt => opt.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("TaskManagementSystem.DataAccessLayer")));
builder.Services.AddTransient<ITaskService, TaskService>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>(); 
builder.Services.AddTransient<ITaskRepository, TaskRepository>();
builder.Services.AddTransient<IRepositoryManager, RepositoryManager>();

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
