using Microsoft.AspNetCore.Mvc;
using todo.Services; using todo.Models;

namespace todo.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController: ControllerBase {

  [HttpGet]
  public ActionResult<List<Todo>> Get() => TodoService.GetAll();

  [HttpGet("{id}")]
  public ActionResult<Todo> Get(int id) {
    var todo = TodoService.GetById(id);
    if (todo != null) {
      return todo;
    }
    return NotFound("Todo não encontrado");
  }

  [HttpPost]
  public ActionResult<Todo> Add(Todo todo) {
    TodoService.Add(todo);
    return CreatedAtAction(nameof(Add), new { id = todo.Id }, todo);
  }

  [HttpPut("{id}")]
  public ActionResult Update(int id, Todo todo) {
    if (id != todo.Id) {
      return BadRequest("Id do todo não corresponde");
    }
    TodoService.Update(todo);
    return NoContent();
  }

  [HttpDelete("{id}")]
  public ActionResult Remove(int id) {
    TodoService.Remove(id);
    return NoContent();
  }
}