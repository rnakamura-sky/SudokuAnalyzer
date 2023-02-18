namespace Sudoku.Domain.ValueObjects
{
    /// <summary>
    /// GroupIdクラス
    /// </summary>
    public class GroupId : ValueObject<GroupId>
    {
        /// <summary>
        /// 指定なし
        /// </summary>
        public static readonly GroupId Empty = new GroupId(-1);

        /// <summary>
        /// 値
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="value"></param>
        public GroupId(int value)
        {
            Value = value;
        }

        /// <summary>
        /// 指定なしか確認
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return this == Empty;
        }

        protected override bool EqualsCore(GroupId other)
        {
            return Value == other.Value;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }
    }
}
