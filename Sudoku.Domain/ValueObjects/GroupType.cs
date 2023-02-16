namespace Sudoku.Domain.ValueObjects
{
    public sealed class GroupType : ValueObject<GroupType>
    {
        public static readonly GroupType Square = new GroupType(1);
        public static readonly GroupType Row = new GroupType(2);
        public static readonly GroupType Column = new GroupType(3);

        public int Value { get; }
        private GroupType(int value)
        {
            Value = value;
        }

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
