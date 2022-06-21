using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;

using System.Collections.Generic;
using System.Threading.Tasks;
using Aserto.TodoApp.Domain.Models;
using Aserto.TodoApp.Domain.Services;
using Aserto.TodoApp.Resources;
using Microsoft.AspNetCore.Cors;

namespace Aserto.TodoApp.Controllers
{
  [ApiController]
  [Route("/user/{userID}")]
  public class GetUserUserIDController : ControllerBase
  {
    private readonly IUserService _userService;
    private readonly IMapper _mapper;


    public GetUserUserIDController(IUserService userService, IMapper mapper)
    {
      _userService = userService;
      _mapper = mapper;
    }

    [HttpGet]
    [Authorize("Aserto")]
    public async Task<IActionResult> GetAllAsync(string userID)
    {
      var result = await _userService.Get(userID);
      return Ok(result.User);
    }
  }
}
