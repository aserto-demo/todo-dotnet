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
      builder.Entity<Todo>().HasKey(p => p.ID);
      builder.Entity<Todo>().Property(p => p.ID).IsRequired().ValueGeneratedOnAdd();
      builder.Entity<Todo>().Property(p => p.Title).IsRequired();
      builder.Entity<Todo>().Property(p => p.OwnerID).IsRequired();
      builder.Entity<Todo>().Property(p => p.Completed).IsRequired();

      // builder.Entity<Todo>().HasData
      // (
      //     new Todo { ID = "100", Title = "Todo 1", Completed = false, OwnerID = "fd0614d3-c39a-4781-b7bd-8b96f5a5100d" },
      //     new Todo { ID = "101", Title = "Todo 2", Completed = false, OwnerID = "fd0614d3-c39a-4781-b7bd-8b96f5a5100d" }
      // );
    }
  }
}