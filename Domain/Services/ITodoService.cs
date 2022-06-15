using System.Collections.Generic;
using System.Threading.Tasks;
using Aserto.TodoApp.Domain.Models;

namespace Aserto.TodoApp.Domain.Services
{
  public interface ITodoService
  {
    Task<IEnumerable<Todo>> ListAsync();
  }
}