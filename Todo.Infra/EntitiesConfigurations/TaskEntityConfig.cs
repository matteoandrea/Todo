using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Domain.Features.Task.Core;

namespace Todo.Infra.EntitiesConfigurations;

internal class TaskEntityConfig : IEntityTypeConfiguration<TaskEntity>
{
	public void Configure(EntityTypeBuilder<TaskEntity> builder)
	{
		builder.ToTable("Task");

		builder.HasKey(x => x.Id);
		builder.HasIndex(x => x.Id);

		builder.Property(x => x.User)
			.HasMaxLength(120)
			.HasColumnType("VARCHAR(120)");

		builder.Property(x => x.Title)
			.HasMaxLength(160)
			.HasColumnType("VARCHAR(160)");

		builder.Property(x => x.Done)
			.HasColumnType("bit");

		builder.Property(x => x.Date);
	}
}
