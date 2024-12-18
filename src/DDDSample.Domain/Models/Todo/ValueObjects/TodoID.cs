﻿using DDDSample.Domain.Models.Shared;

namespace DDDSample.Domain.Models.Todo.ValueObjects
{
    /// <summary>
    /// Todo の識別 ID
    /// </summary>
    public class TodoID : ValueObject<TodoID>
    {
        public TodoID()
        {
            Value = Guid.NewGuid().ToString();
        }

        public TodoID(string value)
        {
            Value = value;
        }

        public string Value { get; }

        protected override bool EqualsCore(TodoID other)
        {
            return this.Value == other.Value;
        }
    }
}
