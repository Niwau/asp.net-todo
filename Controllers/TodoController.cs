using Microsoft.AspNetCore.Mvc;
using todo.Services; using todo.Models;

namespace todo.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController: ControllerBase {

  [HttpGet]
  public ActionResult<List<Todo>> Get() {
    return TodoService.GetAll();
  }

  [HttpGet("{id}")]
  public ActionResult<Todo> Get(int id) {
    var todo = TodoService.GetById(id);
    if (todo != null) {
      return todo;
    }
    return NotFound("Todo não encontrado");
  }


}