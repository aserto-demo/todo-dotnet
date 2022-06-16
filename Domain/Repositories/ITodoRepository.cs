
using System.Collections.Generic;
using System.Threading.Tasks;
using Aserto.TodoApp.Domain.Models;

namespace Aserto.TodoApp.Domain.Repositories
{
  public interface ITodoRepository
  {
    Task<IEnumerable<Todo>> ListAsync();
    Task AddAsync(Todo todo);
    Task<Todo> FindByIdAsync(int id);
    void Update(Todo todo);
  }
}