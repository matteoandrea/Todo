using Microsoft.EntityFrameworkCore;
using Todo.Domain.Features.Task.Core;
using Todo.Infra.Data.EntitiesConfigurations;

namespace Todo.Infra.Data.Context;

public class DataContext : DbContext
{
	public DbSet<TaskEntity> Tasks { get; set; }

	public DataContext(DbContextOptions options) : base(options) { }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new TaskEntityConfig());
	}
}
