namespace Sudoku.Domain.ValueObjects
{

    /// <summary>
    /// グループタイプクラス
    /// </summary>
    public sealed class GroupType : ValueObject<GroupType>
    {

        /// <summary>
        /// 四角形グループ
        /// </summary>
        public static readonly GroupType Square = new GroupType(1);
        
        /// <summary>
        /// 行グループ
        /// </summary>
        public static readonly GroupType Row = new GroupType(2);

        /// <summary>
        /// 列グループ
        /// </summary>
        public static readonly GroupType Column = new GroupType(3);

        /// <summary>
        /// 値
        /// </summary>

        public int Value { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="value"></param>
        private GroupType(int value)
        {
            Value = value;
        }

        /// <summary>
        /// グループタイプリスト取得
        /// </summary>
        /// <returns></returns>
        public static IReadOnlyList<GroupType> ToList()
        {
            return new List<GroupType>() {
                Square,
                Row,
                Column,
            }.AsReadOnly();
        }


        protected override bool EqualsCore(GroupType other)
        {
            return Value == other.Value;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }
    }
}
