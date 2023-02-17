using Sudoku.Domain.ValueObjects;

namespace Sudoku.Domain.Entities
{
    /// <summary>
    /// グループクラス
    /// 決定値が被らないCellを集めて処理するためのクラス
    /// </summary>
    public class Group
    {
        /// <summary>
        /// グループタイプ
        /// </summary>
        public GroupType GroupType { get; }

        /// <summary>
        /// グループId
        /// </summary>
        public int GroupId { get; }

        /// <summary>
        /// Cellリスト
        /// </summary>
        public IReadOnlyList<CellEntity> CellEntities { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="groupType"></param>
        /// <param name="groupId"></param>
        /// <param name="cellEntities"></param>

        public Group(GroupType groupType, int groupId, IReadOnlyList<CellEntity> cellEntities)
        {
            GroupType = groupType;
            GroupId = groupId;
            CellEntities = cellEntities;
        }

        /// <summary>
        /// 消込処理
        /// グループ内の決定値を候補値から除外します
        /// </summary>

        public void Reconcil()
        {
            foreach (var cellValue in CellValue.ToList())
            {
                if (HasDecidedCell(cellValue))
                {
                    Reconcil(cellValue);
                }
            }
        }

        /// <summary>
        /// 消込処理
        /// 指定された値をグループ内のCellに対して候補から除外します。
        /// </summary>
        /// <param name="cellValue"></param>

        public void Reconcil(CellValue cellValue)
        {
            foreach (var cellEntity in CellEntities)
            {
                if (!cellEntity.IsDecided)
                {
                    cellEntity.Reconcil(cellValue);
                }
            }
        }

        /// <summary>
        /// 消込処理
        /// 指定されたCellの組に含まれる候補を除外します。
        /// 指定されたCellには処理を行いません
        /// </summary>
        /// <param name="cellEntities"></param>

        public void Reconcil(IReadOnlyList<CellEntity> cellPair)
        {
            foreach (var cellEntity in CellEntities)
            {
                if (cellEntity.IsDecided)
                {
                    continue;
                }
                if (cellPair.ToList().Any(x => x.EqualsPosition(cellEntity)))
                {
                    continue;
                }
                cellEntity.ExcludeCandidates(cellPair[0]);
            }
        }

        /// <summary>
        /// 指定された値が決定値となっているCellの有無を確認
        /// </summary>
        /// <param name="cellValue"></param>
        /// <returns></returns>
        public bool HasDecidedCell(CellValue cellValue)
        {
            foreach (var cellEntity in CellEntities)
            {
                if (cellEntity.IsDecided && cellEntity.EqualsValue(cellValue))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// グループ内で候補値が一つのCellのみとなっているか確認
        /// TODO: 処理を分割できそう(指定された決定値についてとループ処理
        /// </summary>
        /// <returns></returns>

        public bool HasDecideCell()
        {
            foreach(var cellValue in CellValue.ToList())
            {
                if (HasDecidedCell(cellValue))
                {
                    continue;
                }
                var count = CellEntities.ToList()
                    .Where(x => !x.IsDecided)
                    .Where(x => x.Contains(cellValue))
                    .Count();
                if (count == 1)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 候補が一つのCellに絞られている候補値を決定する処理
        /// </summary>
        /// <returns></returns>
        public CellEntity DecideCell()
        {
            foreach (var cellValue in CellValue.ToList())
            {
                if (HasDecidedCell(cellValue))
                {
                    continue;
                }
                var count = CellEntities.ToList()
                    .Where(x => !x.IsDecided)
                    .Where(x => x.Contains(cellValue))
                    .Count();
                if (count == 1)
                {
                    foreach (var cellEntity in CellEntities)
                    {
                        if (cellEntity.Contains(cellValue))
                        {
                            cellEntity.Decide(cellValue);
                            return cellEntity;
                        }
                    }
                }
            }
            return CellEntity.Nothing;
        }

        /// <summary>
        /// 候補値情報が一致するペアによる消込処理
        /// 2つのCellで同じ2つの候補値となっている場合、他のCellにはその候補値は入らない
        /// </summary>

        public void ReconcilPair()
        {
            foreach (var cell in CellEntities)
            {
                if (cell.IsDecided)
                {
                    continue;
                }

                if (cell.GetCandidateCount() != 2)
                {
                    continue;
                }

                var other = GetPairCell(cell);
                if (other == CellEntity.Nothing)
                {
                    continue;
                }
                var pair = new List<CellEntity>() { cell, other };
                Reconcil(pair);
            }
        }

        /// <summary>
        /// 指定されたCellと同じ候補値となるCellを取得
        /// </summary>
        /// <param name="cellEntity"></param>
        /// <returns></returns>

        public CellEntity GetPairCell(CellEntity cellEntity)
        {
            foreach (var other in CellEntities)
            {
                if (other.EqualsPosition(cellEntity))
                {
                    continue;
                }
                if (other.EqualsCandidates(cellEntity))
                {
                    return other;
                }
            }
            return CellEntity.Nothing;
        }

        /// <summary>
        /// グループ内の決定値が正しいことを確認
        /// 全てのCellに異なる決定値が設定されていることを確認する
        /// </summary>
        /// <returns></returns>

        public bool IsCorrect()
        {
            var cellCount = CellEntities.Count;
            return cellCount == CellEntities.Where(x => x.IsDecided).Select(x => x.Value).Distinct().Count();

        }
    }
}
