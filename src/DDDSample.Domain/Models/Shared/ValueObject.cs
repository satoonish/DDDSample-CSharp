namespace DDDSample.Domain.Models.Shared
{
    public abstract class ValueObject<T>
    {
        public override bool Equals(object? obj)
        {
            if (obj is not T vo)
            {
                return false;
            }
            if (vo == null)
            {
                return false;
            }

            return EqualsCore(vo);
        }

        public static bool operator ==(
            ValueObject<T> left,
            ValueObject<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(
            ValueObject<T> left,
            ValueObject<T> right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            var str = base.ToString();
            if (str == null)
            {
                throw new Exception("Null オブジェクトを変換できません");
            }
            return str;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        protected abstract bool EqualsCore(T other);
    }
}
