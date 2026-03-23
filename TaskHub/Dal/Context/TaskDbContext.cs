using Microsoft.EntityFrameworkCore;

namespace Dal.Context
{
    public sealed class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Entities.TaskEntity> Tasks => Set<Entities.TaskEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.TaskEntity>(entity =>
            {
                entity.ToTable("tasks");

                entity.HasKey(x => x.Id);

                entity.Property(x => x.Title)
                    .HasColumnName("title")
                    .HasMaxLength(200);

                entity.Property(x => x.CreatedUtc)
                    .HasColumnName("created_utc")
                    .IsRequired();

                entity.Property(x => x.CreatedByUserId)
                    .HasColumnName("created_by_user_id")
                    .IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
