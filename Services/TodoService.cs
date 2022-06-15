using System.Collections.Generic;
using System.Threading.Tasks;
using Aserto.TodoApp.Domain.Models;
using Aserto.TodoApp.Domain.Services;
using Aserto.TodoApp.Domain.Repositories;

namespace Aserto.TodoApp.Services
{
  public class TodoService : ITodoService
  {
    private readonly ITodoRepository _todoRepository;

    public TodoService(ITodoRepository todoRepository)
    {
      this._todoRepository = todoRepository;
    }

    public async Task<IEnumerable<Todo>> ListAsync()
    {
      return await _todoRepository.ListAsync();
    }
  }
}