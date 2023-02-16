using Sudoku.Domain.Entities;
using Sudoku.Domain.Logics;

namespace SudokuTest.Tests
{
    [TestClass]
    public class DomainTest
    {
        [TestMethod]
        public void シナリオ()
        {
            var cells = new[] {
                6, 9, 0, 0, 0, 0, 0, 5, 0,
                0, 1, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 2, 0, 0, 0, 0, 0, 0,
                0, 5, 3, 0, 0, 0, 0, 9, 0,
                0, 8, 0, 0, 2, 0, 0, 0, 0,
                0, 0, 0, 0, 7, 0, 0, 0, 0,
                7, 0, 0, 0, 8, 5, 0, 3, 4,
                0, 0, 8, 0, 0, 0, 2, 0, 0,
                0, 0, 0, 0, 0, 9, 0, 1, 0,
            };

            var cellCollection = new CellCollection(cells);

            Assert.AreEqual(81, cellCollection.Cells.Count());

            Assert.AreEqual(6, cellCollection.Cells[0].Value.Value);
            Assert.AreEqual(0, cellCollection.Cells[0].RowIndex);
            Assert.AreEqual(0, cellCollection.Cells[0].ColumnIndex);
            Assert.AreEqual(true, cellCollection.Cells[0].IsFixed);
            Assert.AreEqual(true, cellCollection.Cells[0].IsDecided);
            var candidates = cellCollection.Cells[0].CandidateCollection;
            foreach (var candidate in candidates.Candidates)
            {
                Assert.AreEqual(false, candidate);
            }

            Assert.AreEqual(0, cellCollection.Cells[11].Value.Value);
            Assert.AreEqual(1, cellCollection.Cells[11].RowIndex);
            Assert.AreEqual(2, cellCollection.Cells[11].ColumnIndex);
            Assert.AreEqual(false, cellCollection.Cells[11].IsFixed);
            Assert.AreEqual(false, cellCollection.Cells[11].IsDecided);
            candidates = cellCollection.Cells[11].CandidateCollection;
            foreach (var candidate in candidates.Candidates)
            {
                Assert.AreEqual(true, candidate);
            }

            Assert.AreEqual(0, cellCollection.Cells[80].Value.Value);
            Assert.AreEqual(8, cellCollection.Cells[80].RowIndex);
            Assert.AreEqual(8, cellCollection.Cells[80].ColumnIndex);
            Assert.AreEqual(false, cellCollection.Cells[80].IsFixed);
            Assert.AreEqual(false, cellCollection.Cells[80].IsDecided);

            var logic = new SolutionLogic(cellCollection);

            logic.Reconcil();
            logic.DecideCells();
            logic.DecideCellInGroups();
        }
    }
}