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
  [Route("/user/{userid}")]
  public class GetUserUserIDController : ControllerBase
  {
    private readonly IUserService _userService;
    private readonly IMapper _mapper;


    public GetUserUserIDController(IUserService userService, IMapper mapper)
    {
      _userService = userService;
      _mapper = mapper;
    }

    [EnableCors("CorsPolicy")]
    [HttpGet]
    // [Authorize("Aserto")]
    public async Task<IActionResult> GetAllAsync(string userid)
    {
      var result = await _userService.Get(userid);
      // var resource = _mapper.Map<User, UserResource>(result.User);
      // if (!result.Success)
      //   return BadRequest(result.Message);


      return Ok(result);
    }
  }
}
