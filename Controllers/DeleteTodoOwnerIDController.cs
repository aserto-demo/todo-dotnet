using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Aserto.TodoApp.Controllers
{
  [ApiController]
  [Route("/todo/{ownerID}")]
  public class DeleteTodoOwnerIDController : ControllerBase
  {
    [HttpDelete]
    // [Authorize("Aserto")]
    public String DeleteTodoOwnerID(string ownerID)
    {
      return "Hello from " + ownerID + "!";
    }
  }
}
