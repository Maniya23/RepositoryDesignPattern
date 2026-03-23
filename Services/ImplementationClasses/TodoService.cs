using RepositoryDesignPattern.Models;
using RepositoryDesignPattern.Services.Interfaces;

namespace RepositoryDesignPattern.Services.ImplementationClasses
{
    public class TodoService : ITodoService
    {
        private static readonly List<Todo> _todos =
        [
            new Todo { Id = 1, Title = "Learn Repository Design Pattern", IsCompleted = false, CreatedDate = DateTime.Now },
            new Todo { Id = 2, Title = "Build a simple API", IsCompleted = true, CreatedDate = DateTime.Now.AddDays(-1) }
        ];
        private static int _nextId = 3;

        public void Add(Todo todo)
        {
            todo.Id = _nextId++;
            todo.CreatedDate = DateTime.Now;
            _todos.Add(todo);
        }

        public void Delete(int id)
        {
            var removed = _todos.RemoveAll(t => t.Id == id);
            if (removed == 0)
                throw new KeyNotFoundException($"Todo with Id {id} not found.");
        }

        public IEnumerable<Todo> Get()
        {
            return _todos;
        }

        public Todo GetById(int id)
        {
            return _todos.FirstOrDefault(t => t.Id == id) ??
                throw new KeyNotFoundException($"Todo with Id {id} not found.");
        }

        public void MarkComplete(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id)
                ?? throw new KeyNotFoundException($"Todo with Id {id} not found.");
            todo.IsCompleted = true;
        }

        public void Update(Todo todo)
        {
            var existingTodo = _todos.FirstOrDefault(t => t.Id == todo.Id);

            if (existingTodo == null)
            {
                throw new KeyNotFoundException($"Todo with Id {todo.Id} not found.");
            }

            if (existingTodo != null)
            {
                existingTodo.Title = todo.Title;
                existingTodo.IsCompleted = todo.IsCompleted;
            }
        }
    }
}
