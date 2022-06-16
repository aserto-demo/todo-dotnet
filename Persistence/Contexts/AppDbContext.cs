using Microsoft.EntityFrameworkCore;
using Aserto.TodoApp.Domain.Models;

namespace Aserto.TodoApp.Persistence.Contexts
{
  public class AppDbContext : DbContext
  {
    public DbSet<Todo> Todos { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      builder.Entity<Todo>().ToTable("Todos");
      builder.Entity<Todo>().HasKey(p => p.Id);
      builder.Entity<Todo>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
      builder.Entity<Todo>().Property(p => p.Content).IsRequired();
      builder.Entity<Todo>().Property(p => p.OwnerId).IsRequired();
      builder.Entity<Todo>().Property(p => p.Completed).IsRequired();

      builder.Entity<Todo>().HasData
      (
          new Todo { Id = 100, Content = "Todo 1", Completed = false, OwnerId = "123" },
          new Todo { Id = 101, Content = "Todo 2", Completed = false, OwnerId = "123" }
      );
    }
  }
}