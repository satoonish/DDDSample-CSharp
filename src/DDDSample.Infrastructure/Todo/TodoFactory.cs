using DDDSample.Domain.Models.Todo.Interfaces;

namespace DDDSample.Infrastructure.Todo
{
    public static class TodoFactory
    {
        public static ITodoRepository CreateTodoRepository()
        {
            return new FakeTodoRepository();
        }
    }
}
