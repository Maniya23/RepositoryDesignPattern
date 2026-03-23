using RepositoryDesignPattern.Models;

namespace RepositoryDesignPattern.Services.Interfaces
{
    public interface ITodoService
    {
        IEnumerable<Todo> Get();
        Todo GetById(int id);
        void Add(Todo todo);
        void Update(Todo todo);
        void Delete(int id);
        void MarkComplete(int id);
    }
}
