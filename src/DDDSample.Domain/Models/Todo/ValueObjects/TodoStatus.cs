using DDDSample.Domain.Models.Shared;

namespace DDDSample.Domain.Models.Todo.ValueObjects
{
    /// <summary>
    /// Todo のステータス
    /// </summary>
    public class TodoStatus : ValueObject<TodoStatus>
    {
        public TodoStatus(string id, string name)
        {
            ID = id;
            Name = name;
        }

        public string ID { get; }
        public string Name { get; }

        public override string ToString() => Name;

        protected override bool EqualsCore(TodoStatus other)
        {
            return this.ID == other.ID;
        }
    }
} 
