using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TodoApiDTO.Models.Configuration
{
    public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.ToTable("TodoItems");
            builder.HasKey(ti => ti.Id);
            builder.Property(ti => ti.Name)
                .IsRequired()
                .HasMaxLength(1000);
            builder.Property(ti => ti.IsComplete);
            builder.Property(ti => ti.Secret)
                .HasMaxLength(1000);
        }
    }
}