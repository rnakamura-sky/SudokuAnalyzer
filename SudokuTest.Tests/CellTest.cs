using Sudoku.Domain.Entities;
using Sudoku.Domain.ValueObjects;

namespace SudokuTest.Tests
{
    [TestClass]
    public class CellTest
    {
        [TestMethod]
        public void 決定シナリオ()
        {
            var cell = new CellEntity(0, 0, 0);
            Assert.AreEqual(0, cell.Value.Value);
            Assert.AreEqual(0, cell.RowIndex);
            Assert.AreEqual(0, cell.ColumnIndex);
            Assert.AreEqual(false, cell.IsFixed);
            Assert.AreEqual(false, cell.IsDecided);
            Assert.AreEqual(false, cell.IsOnlyOneCandidate());
            Assert.AreEqual(true, cell.Contains(new CellValue(1)));
            Assert.AreEqual(true, cell.Contains(new CellValue(2)));
            Assert.AreEqual(true, cell.Contains(new CellValue(3)));
            Assert.AreEqual(true, cell.Contains(new CellValue(4)));
            Assert.AreEqual(true, cell.Contains(new CellValue(5)));
            Assert.AreEqual(true, cell.Contains(new CellValue(6)));
            Assert.AreEqual(true, cell.Contains(new CellValue(7)));
            Assert.AreEqual(true, cell.Contains(new CellValue(8)));
            Assert.AreEqual(true, cell.Contains(new CellValue(9)));

            cell.Reconcil(new CellValue(1));
            cell.Reconcil(new CellValue(2));
            cell.Reconcil(new CellValue(3));
            cell.Reconcil(new CellValue(4));
            cell.Reconcil(new CellValue(6));
            cell.Reconcil(new CellValue(7));
            cell.Reconcil(new CellValue(8));
            cell.Reconcil(new CellValue(9));

            Assert.AreEqual(false, cell.IsDecided);
            Assert.AreEqual(true, cell.IsOnlyOneCandidate());
            Assert.AreEqual(false, cell.Contains(new CellValue(1)));
            Assert.AreEqual(false, cell.Contains(new CellValue(2)));
            Assert.AreEqual(false, cell.Contains(new CellValue(3)));
            Assert.AreEqual(false, cell.Contains(new CellValue(4)));
            Assert.AreEqual(true, cell.Contains(new CellValue(5)));
            Assert.AreEqual(false, cell.Contains(new CellValue(6)));
            Assert.AreEqual(false, cell.Contains(new CellValue(7)));
            Assert.AreEqual(false, cell.Contains(new CellValue(8)));
            Assert.AreEqual(false, cell.Contains(new CellValue(9)));

            cell.Decide();

            Assert.AreEqual(true, cell.IsDecided);
            Assert.AreEqual(5, cell.Value.Value);
        }

        [TestMethod]
        public void GroupId取得()
        {
            var cellEntity = new CellEntity(0, 0, 0);
            Assert.AreEqual(0, cellEntity.GetGroupId(GroupType.Square).Value);
            Assert.AreEqual(0, cellEntity.GetGroupId(GroupType.Row).Value);
            Assert.AreEqual(0, cellEntity.GetGroupId(GroupType.Column).Value);

            cellEntity = new CellEntity(0, 8, 8);
            Assert.AreEqual(8, cellEntity.GetGroupId(GroupType.Square).Value);
            Assert.AreEqual(8, cellEntity.GetGroupId(GroupType.Row).Value);
            Assert.AreEqual(8, cellEntity.GetGroupId(GroupType.Column).Value);

            cellEntity = new CellEntity(0, 3, 5);
            Assert.AreEqual(4, cellEntity.GetGroupId(GroupType.Square).Value);
            Assert.AreEqual(3, cellEntity.GetGroupId(GroupType.Row).Value);
            Assert.AreEqual(5, cellEntity.GetGroupId(GroupType.Column).Value);
        }
    }
}
