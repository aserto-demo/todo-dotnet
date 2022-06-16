using System.Collections.Generic;
using System.Threading.Tasks;
using Aserto.TodoApp.Domain.Models;
using Aserto.TodoApp.Domain.Services;
using Aserto.TodoApp.Domain.Repositories;
using Aserto.TodoApp.Domain.Services.Communication;
using System;

namespace Aserto.TodoApp.Services
{
  public class TodoService : ITodoService
  {
    private readonly ITodoRepository _todoRepository;
    private readonly IUnitOfWork _unitOfWork;


    public TodoService(ITodoRepository todoRepository, IUnitOfWork unitOfWork)
    {
      _todoRepository = todoRepository;
      _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Todo>> ListAsync()
    {
      return await _todoRepository.ListAsync();
    }

    public async Task<SaveTodoResponse> SaveAsync(Todo todo)
    {
      try
      {
        await _todoRepository.AddAsync(todo);
        await _unitOfWork.CompleteAsync();

        return new SaveTodoResponse(todo);
      }
      catch (Exception ex)
      {
        // Do some logging stuff
        return new SaveTodoResponse($"An error occurred when saving the todo: {ex.Message}");
      }
    }

    public async Task<SaveTodoResponse> UpdateAsync(Todo todo)
    {
      var existingTodo = await _todoRepository.FindByIdAsync(todo.Id);

      if (existingTodo == null)
        return new SaveTodoResponse("Todo not found.");

      existingTodo.Id = todo.Id;
      existingTodo.Completed = todo.Completed;
      existingTodo.Content = todo.Content;
      existingTodo.OwnerId = todo.OwnerId;

      try
      {
        _todoRepository.Update(existingTodo);
        await _unitOfWork.CompleteAsync();

        return new SaveTodoResponse(existingTodo);
      }
      catch (Exception ex)
      {
        // Do some logging stuff
        return new SaveTodoResponse($"An error occurred when updating the todo: {ex.Message}");
      }
    }
  }
}