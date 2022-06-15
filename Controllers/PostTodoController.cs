using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Aserto.NETCore3.Auth0.Controllers
{
  [ApiController]
  [Route("/todo")]
  public class PostTodoController : ControllerBase
  {
    [HttpPost]
    [Authorize("Aserto")]
    public String PostTodo()
    {
      return "Hello from todo!";
    }
  }
}
