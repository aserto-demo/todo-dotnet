using System.Collections.Generic;
using System.Threading.Tasks;
using Aserto.TodoApp.Domain.Models;
using Aserto.TodoApp.Domain.Services.Communication;
using Aserto.TodoApp.Configuration;
using Microsoft.Extensions.Options;
namespace Aserto.TodoApp.Domain.Services
{
  public interface IUserService
  {
    Task<GetUserResponse> Get(string sub);
  }
}