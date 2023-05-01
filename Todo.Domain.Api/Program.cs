using Microsoft.EntityFrameworkCore;
using Todo.Domain.Features.Task.Handler;
using Todo.Domain.Features.Task.Repository;
using Todo.Infra.Data.Context;
using Todo.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);
{

	builder.Services.AddControllers();
	builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));
	//builder.Services.AddDbContext<DataContext>
	builder.Services.AddTransient<ITaskRepository, TaskRepository>();
	builder.Services.AddTransient<TaskHandler, TaskHandler>();
	builder.Services.AddEndpointsApiExplorer();
	builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
	if (app.Environment.IsDevelopment())
	{
		app.UseSwagger();
		app.UseSwaggerUI();
	}

	app.UseHttpsRedirection();
	app.UseAuthorization();
	app.MapControllers();
	app.Run();
}