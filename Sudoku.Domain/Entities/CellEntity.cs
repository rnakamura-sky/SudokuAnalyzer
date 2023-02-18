using Sudoku.Domain.Exceptions;
using Sudoku.Domain.ValueObjects;

namespace Sudoku.Domain.Entities
{
    /// <summary>
    /// Cellクラス
    /// </summary>
    public sealed class CellEntity
    {
        /// <summary>
        /// Cellとして存在しないことを表すインスタンス
        /// </summary>
        public static readonly CellEntity Nothing = new CellEntity(CellValue.Empty, 0, 0);

        public static readonly int RowIndexMimimumValue = 0;
        public static readonly int RowIndexMaximumValue = 8;
        public static readonly int ColumnIndexMimimumValue = 0;
        public static readonly int ColumnIndexMaximumValue = 8;

        /// <summary>
        /// 行座標
        /// </summary>
        public int RowIndex { get; }

        /// <summary>
        /// 列座標
        /// </summary>
        public int ColumnIndex { get; }

        /// <summary>
        /// 決定値
        /// </summary>
        public CellValue Value { get; private set; }

        /// <summary>
        /// 固定値判定
        /// </summary>
        public bool IsFixed { get; }

        /// <summary>
        /// 決定値判定
        /// </summary>

        public bool IsDecided => Value.IsDecided();

        /// <summary>
        /// 候補値情報
        /// </summary>
        public CandidateCollection CandidateCollection { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="value"></param>
        /// <param name="rowIndex"></param>
        /// <param name="columnIndex"></param>

        public CellEntity(int value, int rowIndex, int columnIndex)
            : this(new CellValue(value), rowIndex, columnIndex)
        {

        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="value"></param>
        /// <param name="rowIndex"></param>
        /// <param name="columnIndex"></param>
        /// <param name="isFixed"></param>
        /// <param name="candidates"></param>
        /// <exception cref="InvalidValueException"></exception>

        public CellEntity(int value, int rowIndex, int columnIndex, bool isFixed, IReadOnlyList<bool> candidates)
        {
            Value = new CellValue(value);
            if (rowIndex < RowIndexMimimumValue || RowIndexMaximumValue < rowIndex)
            {
                throw new InvalidValueException();
            }
            if (columnIndex < ColumnIndexMimimumValue || ColumnIndexMaximumValue < columnIndex)
            {
                throw new InvalidValueException();
            }
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
            IsFixed = isFixed;
            CandidateCollection = new CandidateCollection(candidates);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="cellValue"></param>
        /// <param name="rowIndex"></param>
        /// <param name="columnIndex"></param>
        /// <exception cref="InvalidValueException"></exception>

        public CellEntity(CellValue cellValue, int rowIndex, int columnIndex)
        {
            if (rowIndex < RowIndexMimimumValue || RowIndexMaximumValue < rowIndex)
            {
                throw new InvalidValueException();
            }
            if (columnIndex < ColumnIndexMimimumValue || ColumnIndexMaximumValue < columnIndex)
            {
                throw new InvalidValueException();
            }

            Value = cellValue;
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;

            if (Value == CellValue.Empty)
            {
                IsFixed = false;
                CandidateCollection = new CandidateCollection(true);
            }
            else
            {
                IsFixed = true;
                CandidateCollection = new CandidateCollection(false);
            }
        }

        /// <summary>
        /// 消込処理
        /// 指定された値を候補から外す
        /// </summary>
        /// <param name="cellValue"></param>
        public void Reconcil(CellValue cellValue)
        {
            CandidateCollection.Reconcil(cellValue);
        }

        /// <summary>
        /// 値比較
        /// Cellの値が一致するか確認
        /// </summary>
        /// <param name="cellValue"></param>
        /// <returns></returns>

        public bool EqualsValue(CellValue cellValue)
        {
            return Value.Equals(cellValue);
        }

        /// <summary>
        /// 候補値が一つに絞られているか確認
        /// </summary>
        /// <returns></returns>
        public bool IsOnlyOneCandidate()
        {
            return CandidateCollection.IsOnlyOneCandidate();
        }

        /// <summary>
        /// 候補値情報から決定値を決める
        /// 候補値が一つに絞られている必要がある
        /// </summary>
        public void Decide()
        {
            SetValue(CandidateCollection.GetCellValue());

        }

        /// <summary>
        /// 指定された値を決定値とする
        /// </summary>
        /// <param name="cellValue"></param>

        public void Decide(CellValue cellValue)
        {
            SetValue(cellValue);
        }

        /// <summary>
        /// 指定された値が候補値に含まれるか確認
        /// </summary>
        /// <param name="cellValue"></param>
        /// <returns></returns>

        public bool Contains(CellValue cellValue)
        {
            return CandidateCollection.Contains(cellValue);
        }

        /// <summary>
        /// Cell情報を初期化する
        /// </summary>

        public void Reset()
        {
            if (IsFixed)
            {
                return;
            }
            Value = CellValue.Empty;
            CandidateCollection.On();
        }

        /// <summary>
        /// 候補となっている値の数を取得
        /// </summary>
        /// <returns></returns>
        public int GetCandidateCount()
        {
            return CandidateCollection.GetCandidateCount();
        }

        /// <summary>
        /// 指定されたCell情報と同じ位置情報か確認
        /// </summary>
        /// <param name="cellEntity"></param>
        /// <returns></returns>

        public bool EqualsPosition(CellEntity cellEntity)
        {
            if (RowIndex != cellEntity.RowIndex)
            {
                return false;
            }
            if (ColumnIndex != cellEntity.ColumnIndex)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 指定されたCell情報と候補値の情報が一致するか確認
        /// </summary>
        /// <param name="cellEntity"></param>
        /// <returns></returns>

        public bool EqualsCandidates(CellEntity cellEntity)
        {
            return CandidateCollection.EqualsCandidates(cellEntity.CandidateCollection);
        }

        /// <summary>
        /// 指定されたCell情報の候補値を除外する
        /// </summary>
        /// <param name="cellEntity"></param>
        public void ExcludeCandidates(CellEntity cellEntity)
        {
            CandidateCollection.Exclude(cellEntity.CandidateCollection);
        }

        /// <summary>
        /// 決定値設定処理
        /// 候補値を全て外す
        /// </summary>
        /// <param name="cellValue"></param>

        private void SetValue(CellValue cellValue)
        {
            Value = cellValue;
            CandidateCollection.Off();
        }

        /// <summary>
        /// 所属しているGroupIdを返す
        /// TODO: GroupIdをフィールドに持っていないので、他のクラスに持たせたい
        /// </summary>
        /// <param name="groupType"></param>
        /// <returns></returns>
        public GroupId GetGroupId(GroupType groupType)
        {
            if (groupType == GroupType.Square)
            {
                var rowId = RowIndex / 3;
                var columnId = ColumnIndex / 3;
                var groupId = rowId * 3 + columnId;
                return new GroupId(groupId);
            }
            if (groupType == GroupType.Row)
            {
                return new GroupId(RowIndex);
            }
            if (groupType == GroupType.Column)
            {
                return new GroupId(ColumnIndex);
            }
            return GroupId.Empty;
        }
    }
}
