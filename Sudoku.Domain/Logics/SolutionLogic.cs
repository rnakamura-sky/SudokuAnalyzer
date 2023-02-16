using Sudoku.Domain.Entities;

namespace Sudoku.Domain.Logics
{
    public class SolutionLogic
    {
        private CellCollection _cellCollection;

        public SolutionLogic(CellCollection cellCollection)
        {
            _cellCollection = cellCollection;
        }

        /// <summary>
        /// 消込
        /// </summary>
        public void Reconcil()
        {
            foreach (var groupCollection in GroupFactory.GetGroupCollections(_cellCollection))
            {
                foreach (var group in groupCollection.Groups)
                {
                    group.Reconcil();
                }
            }
        }

        public void Reconcil(CellEntity cellEntity)
        {
            foreach (var group in GroupFactory.GetGroups(cellEntity, _cellCollection))
            {
                group.Reconcil(cellEntity.Value);
            }
        }

        public void DecideCells()
        {
            var cellEntity = DecideCell();
            while (cellEntity != CellEntity.Nothing)
            {
                Reconcil(cellEntity);
                cellEntity = DecideCell();
            }
        }

        public CellEntity DecideCell()
        {
            foreach (var cell in _cellCollection.Cells)
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

        public void DecideCellInGroups()
        {
            var cellEntity = DecideCellInGroup();
            while (cellEntity != CellEntity.Nothing)
            {
                Reconcil(cellEntity);
                cellEntity = DecideCellInGroup();
            }
        }

        public CellEntity DecideCellInGroup()
        {

            foreach (var groupCollection in GroupFactory.GetGroupCollections(_cellCollection))
            {
                foreach (var group in groupCollection.Groups)
                {
                    var cellEntity = group.DecideCell();
                    if (cellEntity != CellEntity.Nothing)
                    {
                        cellEntity.Decide();
                        return cellEntity;
                    }
                }
            }
            return CellEntity.Nothing;
        }

    }
}
