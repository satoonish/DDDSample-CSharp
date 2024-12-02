using DDDSample.Domain.Models.Todo.ValueObjects;

namespace DDDSample.Domain.Models.Todo.Entities
{
    public class TodoEntity
    {
        public TodoEntity(
            TodoID id,
            TodoTitle title,
            TodoDescription description,
            TodoDeadline deadline,
            TodoStatus status)
        {
            CreationTime = DateTime.Now;
            ID = id;
            Title = title;
            Description = description;
            Deadline = deadline;
            Status = status;
        }

        public DateTime CreationTime { get; }
        public TodoID ID { get; }
        public TodoTitle Title { get; }
        public TodoDescription Description { get; }
        public TodoDeadline Deadline { get; }
        public TodoStatus Status { get; }
    }
}
