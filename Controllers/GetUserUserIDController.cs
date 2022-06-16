using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Aserto.TodoApp.Controllers
{
  [ApiController]
  [Route("/user/{userid}")]
  public class GetUserUserIDController : ControllerBase
  {
    [HttpGet]
    // [Authorize("Aserto")]
    public String GetUserUserID(string userid)
    {
      return "Hello from " + userid + "!";
    }
  }
}
