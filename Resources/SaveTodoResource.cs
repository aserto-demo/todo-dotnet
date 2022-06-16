using System.ComponentModel.DataAnnotations;

namespace Aserto.TodoApp.Resources
{
  public class SaveTodoResource
  {
    public int Id { get; set; }
    [Required]

    public string Content { get; set; }

    public string OwnerId { get; set; }

    public bool Completed { get; set; }
  }
}