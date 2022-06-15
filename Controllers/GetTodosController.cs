using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

using System.Collections.Generic;
using System.Threading.Tasks;
using Aserto.TodoApp.Domain.Models;
using Aserto.TodoApp.Domain.Services;

namespace Aserto.TodoApp.Controllers
{
  [ApiController]
  [Route("/todos")]
  public class GetTodosController : ControllerBase
  {
    private readonly ITodoService _todoService;

    public GetTodosController(ITodoService todoService)
    {
      _todoService = todoService;
    }

    [HttpGet]
    // [Authorize("Aserto")]

    public async Task<IEnumerable<Todo>> GetAllAsync()
    {
      var todos = await _todoService.ListAsync();
      return todos;
    }
  }
}
