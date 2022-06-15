using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Aserto.TodoApp.Domain.Models;
using Aserto.TodoApp.Domain.Repositories;
using Aserto.TodoApp.Persistence.Contexts;

namespace Aserto.TodoApp.Persistence.Repositories
{
  public class TodoRepository : BaseRepository, ITodoRepository
  {
    public TodoRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Todo>> ListAsync()
    {
      return await _context.Todos.ToListAsync();
    }
  }
}