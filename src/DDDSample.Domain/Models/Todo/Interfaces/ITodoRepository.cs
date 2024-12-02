using DDDSample.Domain.Models.Todo.Entities;
using DDDSample.Domain.Models.Todo.ValueObjects;

namespace DDDSample.Domain.Models.Todo.Interfaces
{
    public interface ITodoRepository
    {
        /// <summary>
        /// Todo エンティティを保存します
        /// </summary>
        Task Save(TodoEntity entity);

        /// <summary>
        /// 指定した Todo ID のエンティティを削除します
        /// </summary>
        /// <param name="id">Todo の識別 ID</param>
        Task DeleteByID(TodoID id);

        /// <summary>
        /// すべての Todo エンティティを取得します
        /// </summary>
        Task<List<TodoEntity>> FindAll();

        /// <summary>
        /// 指定したステータスのすべての Todo エンティティを取得します
        /// </summary>
        /// <param name="status">Todo のステータス</param>
        Task<List<TodoEntity>> FindAllByStatus(TodoStatus status);
    }
}
