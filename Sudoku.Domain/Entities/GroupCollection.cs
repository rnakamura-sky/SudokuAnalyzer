using System.Text.RegularExpressions;

namespace Sudoku.Domain.Entities
{
    /// <summary>
    /// 特定のGroupTypeのグループ情報管理クラス
    /// </summary>
    public class GroupCollection
    {
        /// <summary>
        /// グループリスト
        /// </summary>

        private IReadOnlyCollection<Group> _groups { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="groups"></param>
        public GroupCollection(IReadOnlyCollection<Group> groups)
        {
            _groups = groups;
        }

        /// <summary>
        /// 消込処理
        /// 決定値を候補値から除外します。
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Reconcil()
        {
            foreach (var group in _groups)
            {
                group.Reconcil();
            }
        }

        /// <summary>
        /// グループ内特定候補値設定
        /// グループないで1つのCellのみに候補となっている値を設定する
        /// </summary>
        /// <returns></returns>
        public CellEntity DecideCell()
        {
            foreach (var group in _groups)
            {
                if (group.HasDecideCell())
                {
                    var cellEntity = group.DecideCell();
                    return cellEntity;
                }
            }
            return CellEntity.Nothing;
        }

        /// <summary>
        /// 設定されている値が正しいことを確認
        /// </summary>
        /// <returns></returns>
        public bool IsCorrect()
        {
            foreach (var group in _groups)
            {
                if (!group.IsCorrect())
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 候補値が2個で同じ組み合わせのCellの候補値消込処理
        /// </summary>
        public void ReconcilPair()
        {
            foreach (var group in _groups)
            {
                group.ReconcilPair();
            }
        }
    }
}
