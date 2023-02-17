﻿namespace Sudoku.Domain.ValueObjects
{
    /// <summary>
    /// ValueObjectクラス
    /// クラスをプリミティブ型と同様に扱うためのクラス
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ValueObject<T> where T : ValueObject<T>
    {

        public override bool Equals(object? obj)
        {
            var vo = obj as T;
            if (vo is null)
            {
                return false;
            }
            return EqualsCore(vo);
        }

        public static bool operator ==(ValueObject<T> vo1, ValueObject<T> vo2)
        {
            return Equals(vo1, vo2);
        }

        public static bool operator !=(ValueObject<T> vo1, ValueObject<T> vo2)
        {
            return !Equals(vo1, vo2);
        }

        public override int GetHashCode()
        {
            return GetHashCodeCore();
        }

        protected abstract bool EqualsCore(T other);
        protected abstract int GetHashCodeCore();
    }
}
