using DDDSample.Domain.Models.Shared;

namespace DDDSample.Domain.Models.Todo.ValueObjects
{
    /// <summary>
    /// Todo の詳細
    /// </summary>
    public class TodoDescription : ValueObject<TodoDescription>
    {
        private const int MaxLength = 300;

        public TodoDescription(string value)
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

        protected override bool EqualsCore(TodoDescription other)
        {
            return this.Value == other.Value;
        }

        private static bool IsWithinMaxLength(string value)
        {
            return value.Length <= MaxLength;
        }
    }
}
