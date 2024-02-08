using todo.Models;
namespace todo.Services;

public static class TodoService {
  static readonly List<Todo> todos;

  static TodoService() {
    todos = [
      new Todo { Id = 1, Title = "Estudar C#", IsComplete = false },
      new Todo { Id = 2, Title = "Estudar .NET", IsComplete = false },
      new Todo { Id = 3, Title = "Estudar ASP.NET", IsComplete = false }
    ];
  }

  public static void Add(Todo todo) {
    todos.Add(todo);
  }

  public static void Remove(int id) {
    var todo = todos.Find(todo => todo.Id == id);
    if (todo != null){
      todos.Remove(todo);
    }
  }

  public static void Update(Todo todo) {
    var index = todos.FindIndex(todo => todo.Id == todo.Id);
    todos[index] = todo;
  }

  public static Todo? GetById(int id) => todos.Find(todo => todo.Id == id);

  public static List<Todo> GetAll() => todos;
}

