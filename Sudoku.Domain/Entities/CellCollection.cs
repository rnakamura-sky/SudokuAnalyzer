using Sudoku.Domain.ValueObjects;

namespace Sudoku.Domain.Entities
{
    /// <summary>
    /// Cell情報Listクラス
    /// </summary>
    public sealed class CellCollection
    {
        private IReadOnlyList<CellEntity> _cells;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CellCollection()
        {
            var cells = new List<CellEntity>();
            for (int row = CellEntity.RowIndexMimimumValue; row <= CellEntity.RowIndexMaximumValue; ++row)
            {
                for (int col = CellEntity.ColumnIndexMimimumValue; col <= CellEntity.ColumnIndexMaximumValue; ++col)
                {
                    cells.Add(new CellEntity(CellValue.Empty, row, col));
                }
            }
            _cells = cells.AsReadOnly();
        }

        /// <summary>
        /// コンストラクタ
        /// 指定されたCell情報で初期化
        /// </summary>
        /// <param name="cellValues"></param>
        public CellCollection(IEnumerable<int> cellValues)
        {
            var cells = new List<CellEntity>();
            var index = 0;
            foreach (var cellValue in cellValues)
            {

                var row = index / (CellEntity.RowIndexMaximumValue + 1);
                var col = index % (CellEntity.ColumnIndexMaximumValue + 1);
                cells.Add(new CellEntity(cellValue, row, col));
                index++;
            }
            _cells = cells.AsReadOnly();
        }

        /// <summary>
        /// コンストラクタ
        /// 指定されたセル情報で初期化
        /// </summary>
        /// <param name="cells"></param>
        public CellCollection(IReadOnlyList<CellEntity> cells)
        {
            _cells = cells;
        }

        /// <summary>
        /// 候補値全体(候補から外れた値含め)の数を取得
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _cells.Count;
        }

        /// <summary>
        /// 候補値が1つに絞られているCellの値を決定する
        /// </summary>
        /// <returns></returns>
        public CellEntity DecideCell()
        {
            foreach (var cell in _cells)
            {
                if (cell.IsDecided)
                {
                    continue;
                }
                if (cell.IsOnlyOneCandidate())
                {
                    cell.Decide();
                    return cell;
                }
            }
            return CellEntity.Nothing;
        }

        /// <summary>
        /// 初期状態に戻す
        /// </summary>
        public void Reset()
        {
            foreach (var cellEntity in _cells)
            {
                cellEntity.Reset();
            }
        }

        /// <summary>
        /// 決定していないCellがあるか確認
        /// </summary>
        /// <returns></returns>
        public bool ExistsEmpty()
        {
            return !_cells.All(x => x.IsDecided);
        }

        /// <summary>
        /// Cellの一覧を取得する
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<CellEntity> GetCells()
        {
            return _cells;
        }

        /// <summary>
        /// Cellを取得する
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public CellEntity GetCellEntity(int index)
        {
            return _cells[index];
        }

        /// <summary>
        /// Cellを取得する
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public CellEntity GetCellEntity(int row, int column)
        {
            var index = row * 9 + column;
            return GetCellEntity(index);

        }
    }
}
