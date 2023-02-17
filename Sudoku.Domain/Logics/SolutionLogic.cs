using Sudoku.Domain.Entities;

namespace Sudoku.Domain.Logics
{
    /// <summary>
    /// 解答ロジッククラス
    /// </summary>
    public class SolutionLogic
    {
        /// <summary>
        /// Cell情報
        /// </summary>
        private readonly CellCollection _cellCollection;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="cellCollection"></param>
        public SolutionLogic(CellCollection cellCollection)
        {
            _cellCollection = cellCollection;
        }

        /// <summary>
        /// 消込処理
        /// 決定値を候補値から除外します
        /// </summary>
        public void Reconcil()
        {
            foreach (var groupCollection in GroupFactory.GetGroupCollections(_cellCollection))
            {
                groupCollection.Reconcil();
            }
        }

        /// <summary>
        /// 消込処理
        /// 指定されたCellの決定値を候補値から除外します。
        /// </summary>
        /// <param name="cellEntity"></param>
        public void Reconcil(CellEntity cellEntity)
        {
            // 指定されたCellが含まれるGroupを取得して処理を行う
            foreach (var group in GroupFactory.GetGroups(cellEntity, _cellCollection))
            {
                group.Reconcil(cellEntity.Value);
            }
        }

        /// <summary>
        /// 候補値が一つに絞られているCellの設定
        /// 設定ができたら候補値の消込処理を行う
        /// 対象がなくなるまで繰り返し処理を行う
        /// </summary>
        public void DecideCells()
        {
            var cellEntity = _cellCollection.DecideCell();
            while (cellEntity != CellEntity.Nothing)
            {
                Reconcil(cellEntity);
                cellEntity = _cellCollection.DecideCell();
            }
        }

        /// <summary>
        /// グループ内で特定の候補値が1つのCellのみの場合に設定
        /// 設定ができたら候補値の消込処理を行う
        /// 対象がなくなるまで繰り返し処理を行う
        /// TODO:繰り返し処理の見直しを検討してよさそう。候補値ごとでも良いと思われる
        /// </summary>
        public void DecideCellInGroups()
        {
            var cellEntity = DecideCellInGroup();
            while (cellEntity != CellEntity.Nothing)
            {
                Reconcil(cellEntity);
                cellEntity = DecideCellInGroup();
            }
        }

        /// <summary>
        /// グループ内で特定の候補値が1つのCellのみの場合に設定
        /// </summary>
        /// <returns></returns>
        public CellEntity DecideCellInGroup()
        {
            foreach (var groupCollection in GroupFactory.GetGroupCollections(_cellCollection))
            {
                return groupCollection.DecideCell();
            }
            return CellEntity.Nothing;
        }

        /// <summary>
        /// 候補値が2個で同じ組み合わせのCellの候補値消込処理
        /// </summary>
        public void ReconcilPair()
        {
            foreach (var groupCollection in GroupFactory.GetGroupCollections(_cellCollection))
            {
                groupCollection.ReconcilPair();
            }
        }

        /// <summary>
        /// クリア判定処理
        /// </summary>
        /// <returns></returns>
        public bool IsClear()
        {
            if (_cellCollection.ExistsEmpty())
            {
                return false;
            }
            foreach (var groupCollection in GroupFactory.GetGroupCollections(_cellCollection))
            {
                if (!groupCollection.IsCorrect())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
