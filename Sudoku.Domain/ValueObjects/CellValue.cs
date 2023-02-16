using Sudoku.Domain.Exceptions;

namespace Sudoku.Domain.ValueObjects
{
    public class CellValue : ValueObject<CellValue>
    {
        public static readonly CellValue Empty = new CellValue(0);

        private static readonly int MaxValue = 9;
        private static readonly int MinValue = 1;
        private static readonly int EmptyValue = 0;

        public int Value { get; }

        public CellValue(int value)
        {
            if (value == EmptyValue)
            {
                // 何もしない
            }
            else if (value < MinValue || MaxValue < value)
            {
                throw new InvalidValueException();
            }
            Value = value;
        }
        public bool IsDecided()
        {
            return this != Empty;
        }

        public int GetIndex()
        {
            return Value - 1;
        }

        protected override bool EqualsCore(CellValue other)
        {
            return Value == other.Value;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        public static IReadOnlyList<CellValue> ToList()
        {
            var result = new List<CellValue>();
            for (int i = MinValue; i <= MaxValue; ++i)
            {
                result.Add(new CellValue(i));
            }
            return result.AsReadOnly();
        }
    }
}
