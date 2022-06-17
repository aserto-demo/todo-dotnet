namespace Aserto.TodoApp.Resources
{
  public class TodoResource
  {
    public int Id { get; set; }
    public string Content { get; set; }
    public bool Completed { get; set; }
    public string OwnerId { get; set; }
  }
}