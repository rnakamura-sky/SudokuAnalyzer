using Sudoku.Domain.Exceptions;

namespace Sudoku.Domain.ValueObjects
{
    /// <summary>
    /// Cell決定値クラス
    /// </summary>
    public class CellValue : ValueObject<CellValue>
    {
        /// <summary>
        /// 未決定値
        /// </summary>
        public static readonly CellValue Empty = new CellValue(EmptyValue);

        private static readonly int MaxValue = 9;
        private static readonly int MinValue = 1;
        private static readonly int EmptyValue = 0;

        /// <summary>
        /// 値
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="InvalidValueException"></exception>

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

        /// <summary>
        /// 決定値かどうか
        /// </summary>
        /// <returns></returns>
        public bool IsDecided()
        {
            return this != Empty;
        }

        protected override bool EqualsCore(CellValue other)
        {
            return Value == other.Value;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        /// <summary>
        /// 指定できる決定値リスト
        /// </summary>
        /// <returns></returns>

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
