using Sudoku.Domain.Exceptions;
using Sudoku.Domain.ValueObjects;

namespace Sudoku.Domain.Entities
{
    public sealed class CellEntity
    {
        public static readonly CellEntity Nothing = new CellEntity(CellValue.Empty, 0, 0);

        public static readonly int RowIndexMimimumValue = 0;
        public static readonly int RowIndexMaximumValue = 8;
        public static readonly int ColumnIndexMimimumValue = 0;
        public static readonly int ColumnIndexMaximumValue = 8;

        public int RowIndex { get; }
        public int ColumnIndex { get; }
        public CellValue Value { get; private set; }

        public bool IsFixed { get; }

        public bool IsDecided => Value.IsDecided();

        public CandidateCollection CandidateCollection { get; }


        public CellEntity(int value, int rowIndex, int columnIndex)
            : this(new CellValue(value), rowIndex, columnIndex)
        {

        }

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

        public void Reconcil(CellValue cellValue)
        {
            CandidateCollection.Reconcil(cellValue);
        }

        public bool EqualsValue(CellValue cellValue)
        {
            return Value.Equals(cellValue);
        }

        public bool IsOnlyOneCandidate()
        {
            return CandidateCollection.IsOnlyOneCandidate();
        }

        public void Decide()
        {
            SetValue(CandidateCollection.GetCellValue());

        }

        public void SetValue(CellValue cellValue)
        {
            Value = cellValue;
            CandidateCollection.Off();
        }

        public bool Contains(CellValue cellValue)
        {
            return CandidateCollection.Contains(cellValue);
        }
    }
}
