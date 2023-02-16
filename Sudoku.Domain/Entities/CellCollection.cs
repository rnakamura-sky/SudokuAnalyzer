using Sudoku.Domain.ValueObjects;

namespace Sudoku.Domain.Entities
{
    public sealed class CellCollection
    {
        public IReadOnlyList<CellEntity> Cells;

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
            Cells = cells.AsReadOnly();
        }

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
            Cells = cells.AsReadOnly();
        }
    }
}
