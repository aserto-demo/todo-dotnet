using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Aserto.NETCore3.Auth0.Controllers
{
  [ApiController]
  [Route("/todo/{ownerID}")]
  public class PutTodoOwnerIDController : ControllerBase
  {
    [HttpPut]
    // [Authorize("Aserto")]
    public String PutTodoOwnerID(string ownerID)
    {
      return "Hello from " + ownerID + "!";
    }
  }
}
