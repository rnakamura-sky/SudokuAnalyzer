using Sudoku.Domain.ValueObjects;

namespace Sudoku.Domain.Entities
{
    public class Group
    {
        public GroupType GroupType { get; }

        public int GroupId { get; }
        public IReadOnlyList<CellEntity> CellEntities { get; }

        public Group(GroupType groupType, int groupId, IReadOnlyList<CellEntity> cellEntities)
        {
            GroupType = groupType;
            GroupId = groupId;
            CellEntities = cellEntities;
        }

        public void Reconcil()
        {
            foreach (var cellValue in CellValue.ToList())
            {
                Reconcil(cellValue);
            }
        }

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

        public bool HasDecidedCell(CellValue cellValue)
        {
            foreach (var cellEntity in CellEntities)
            {
                if (!cellEntity.IsDecided)
                {
                    continue;
                }
                if (cellEntity.EqualsValue(cellValue))
                {
                    return true;
                }
            }
            return false;
        }

        public CellEntity DecideCell()
        {
            foreach (var cellValue in CellValue.ToList())
            {
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
                            return cellEntity;
                        }
                    }
                }
            }
            return CellEntity.Nothing;
        }
    }
}
