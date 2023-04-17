using Microsoft.EntityFrameworkCore;
using Todo.Domain.Features.Task.Core;
using Todo.Infra.EntitiesConfigurations;

namespace Todo.Infra.Context;

internal class DataContext : DbContext
{
	public DbSet<TaskEntity> Tasks { get; set; }

	public DataContext(DbContextOptions options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new TaskEntityConfig());
	}
}
