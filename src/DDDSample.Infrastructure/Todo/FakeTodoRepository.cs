using DDDSample.Domain.Models.Todo.Entities;
using DDDSample.Domain.Models.Todo.Interfaces;
using DDDSample.Domain.Models.Todo.ValueObjects;

namespace DDDSample.Infrastructure.Todo
{
    /// <summary>
    /// DB を使わない仮の Todo リポジトリ
    /// </summary>
    internal class FakeTodoRepository : ITodoRepository
    {
        private List<TodoEntity> _repository = [];

        public Task Save(TodoEntity entity)
        {
            _repository.Add(entity);
            return Task.CompletedTask;
        }

        public Task DeleteByID(TodoID id)
        {
            var deleteEntity = _repository.FirstOrDefault(e => e.ID == id);
            if (deleteEntity != null)
            {
                _repository.Remove(deleteEntity);
            }
            return Task.CompletedTask;
        }

        public Task<List<TodoEntity>> FindAll()
        {
            return Task.FromResult(_repository);
        }

        public Task<List<TodoEntity>> FindAllByStatus(TodoStatus status)
        {
            var result = new List<TodoEntity>();

            foreach (var entity in _repository)
            {
                if (entity.Status == status)
                {
                    result.Add(entity);
                }
            }

            return Task.FromResult(result);
        }
    }
}
