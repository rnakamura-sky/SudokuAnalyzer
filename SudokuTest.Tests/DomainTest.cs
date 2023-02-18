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

            Assert.AreEqual(81, cellCollection.Count());

            var cellEntity = cellCollection.GetCellEntity(0);
            Assert.AreEqual(6, cellEntity.Value.Value);
            Assert.AreEqual(0, cellEntity.RowIndex);
            Assert.AreEqual(0, cellEntity.ColumnIndex);
            Assert.AreEqual(true, cellEntity.IsFixed);
            Assert.AreEqual(true, cellEntity.IsDecided);
            var candidates = cellEntity.CandidateCollection;
            foreach (var candidate in candidates.Candidates)
            {
                Assert.AreEqual(false, candidate);
            }

            cellEntity = cellCollection.GetCellEntity(11);
            Assert.AreEqual(0, cellEntity.Value.Value);
            Assert.AreEqual(1, cellEntity.RowIndex);
            Assert.AreEqual(2, cellEntity.ColumnIndex);
            Assert.AreEqual(false, cellEntity.IsFixed);
            Assert.AreEqual(false, cellEntity.IsDecided);
            candidates = cellEntity.CandidateCollection;
            foreach (var candidate in candidates.Candidates)
            {
                Assert.AreEqual(true, candidate);
            }

            cellEntity = cellCollection.GetCellEntity(80);
            Assert.AreEqual(0, cellEntity.Value.Value);
            Assert.AreEqual(8, cellEntity.RowIndex);
            Assert.AreEqual(8, cellEntity.ColumnIndex);
            Assert.AreEqual(false, cellEntity.IsFixed);
            Assert.AreEqual(false, cellEntity.IsDecided);

        }

        [TestMethod]
        public void 問題を解く_1()
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
            Solve(cells);
        }

        [TestMethod]
        public void 問題を解く_2()
        {
            /*
            000000010
            000000000
            500800490
            000009540
            060000000
            000010003
            000090050
            034020007
            020073000
             */
            var cells = new[]
            {
                0, 0, 0, 0, 0, 0, 0, 1, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0,
                5, 0, 0, 8, 0, 0, 4, 9, 0,
                0, 0, 0, 0, 0, 9, 5, 4, 0,
                0, 6, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 1, 0, 0, 0, 3,
                0, 0, 0, 0, 9, 0, 0, 5, 0,
                0, 3, 4, 0, 2, 0, 0, 0, 7,
                0, 2, 0, 0, 7, 3, 0, 0, 0,
            };
            Solve(cells);
        }

        private void Solve(IEnumerable<int> cells)
        {

            var cellCollection = new CellCollection(cells);

            var logic = new SolutionLogic(cellCollection);

            logic.Reconcil();

            for (int i = 0; i < 50; ++i)
            {
                logic.DecideCells();
                logic.DecideCellInGroups();
                logic.ReconcilPair();
                logic.ReconcilGroup();

                if (logic.IsClear())
                {
                    break;
                }
            }
            Assert.AreEqual(true, logic.IsClear());
        }
    }
}