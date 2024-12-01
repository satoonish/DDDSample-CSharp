using DDDSample.Domain.Models.Shared;

namespace DDDSample.Domain.Models.Todo.ValueObjects
{
    /// <summary>
    /// Todo の締め切り
    /// </summary>
    public class TodoDeadline : ValueObject<TodoDeadline>
    {
        public TodoDeadline(DateTime value)
        {
            Value = value;
        }

        /// <summary>
        /// システム時刻が締め切りを過ぎたか
        /// </summary>
        public bool IsPastDeadline => DateTime.Now > Value;

        public int Year => Value.Year;
        public int Month => Value.Month;
        public int Day => Value.Day;

        private DateTime Value { get; }

        protected override bool EqualsCore(TodoDeadline other)
        {
            return this.Value == other.Value;
        }
    }
}
