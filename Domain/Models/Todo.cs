
using System.Collections.Generic;

namespace Aserto.TodoApp.Domain.Models
{
  public class Todo
  {
    public int Id { get; set; }
    public string Content { get; set; }
    public bool Completed { get; set; }
    public string OwnerId { get; set; }
  }
}