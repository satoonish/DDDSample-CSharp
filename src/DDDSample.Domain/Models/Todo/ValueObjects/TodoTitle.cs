using DDDSample.Domain.Models.Shared;

namespace DDDSample.Domain.Models.Todo.ValueObjects
{
    /// <summary>
    /// Todo のタイトル
    /// </summary>
    public class TodoTitle : ValueObject<TodoTitle>
    {
        private const int MaxLength = 100;

        public TodoTitle(string value)
        {
            if (value == null)
            {
                Value = string.Empty;
                return;
            }
            if (IsWithinMaxLength(value))
            {
                throw new ArgumentOutOfRangeException(
                    $"最大文字数（{MaxLength}）を超えています");
            }
            Value = value;
        }

        public string Value { get; }

        protected override bool EqualsCore(TodoTitle other)
        {
            return this.Value == other.Value;
        }

        private static bool IsWithinMaxLength(string value)
        {
            return value.Length <= MaxLength;
        }
    }
}
