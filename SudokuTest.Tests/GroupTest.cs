using Sudoku.Domain.Entities;
using Sudoku.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuTest.Tests
{
    [TestClass]
    public class GroupTest
    {
        [TestMethod]
        public void SquareGroup取得()
        {
            var cells = new[] {
                0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0,
            };
            var cellCollection = new CellCollection(cells);

            var group = GroupFactory.GetGroup(GroupType.Square, 0, cellCollection);
            Assert.AreEqual(9, group.CellEntities.Count);
            Assert.AreEqual(0, group.CellEntities[0].RowIndex);
            Assert.AreEqual(0, group.CellEntities[0].ColumnIndex);
            Assert.AreEqual(0, group.CellEntities[1].RowIndex);
            Assert.AreEqual(1, group.CellEntities[1].ColumnIndex);
            Assert.AreEqual(0, group.CellEntities[2].RowIndex);
            Assert.AreEqual(2, group.CellEntities[2].ColumnIndex);
            Assert.AreEqual(1, group.CellEntities[3].RowIndex);
            Assert.AreEqual(0, group.CellEntities[3].ColumnIndex);
            Assert.AreEqual(1, group.CellEntities[4].RowIndex);
            Assert.AreEqual(1, group.CellEntities[4].ColumnIndex);
            Assert.AreEqual(1, group.CellEntities[5].RowIndex);
            Assert.AreEqual(2, group.CellEntities[5].ColumnIndex);
            Assert.AreEqual(2, group.CellEntities[6].RowIndex);
            Assert.AreEqual(0, group.CellEntities[6].ColumnIndex);
            Assert.AreEqual(2, group.CellEntities[7].RowIndex);
            Assert.AreEqual(1, group.CellEntities[7].ColumnIndex);
            Assert.AreEqual(2, group.CellEntities[8].RowIndex);
            Assert.AreEqual(2, group.CellEntities[8].ColumnIndex);

            group = GroupFactory.GetGroup(GroupType.Square, 8, cellCollection);
            Assert.AreEqual(9, group.CellEntities.Count);
            Assert.AreEqual(6, group.CellEntities[0].RowIndex);
            Assert.AreEqual(6, group.CellEntities[0].ColumnIndex);
            Assert.AreEqual(6, group.CellEntities[1].RowIndex);
            Assert.AreEqual(7, group.CellEntities[1].ColumnIndex);
            Assert.AreEqual(6, group.CellEntities[2].RowIndex);
            Assert.AreEqual(8, group.CellEntities[2].ColumnIndex);
            Assert.AreEqual(7, group.CellEntities[3].RowIndex);
            Assert.AreEqual(6, group.CellEntities[3].ColumnIndex);
            Assert.AreEqual(7, group.CellEntities[4].RowIndex);
            Assert.AreEqual(7, group.CellEntities[4].ColumnIndex);
            Assert.AreEqual(7, group.CellEntities[5].RowIndex);
            Assert.AreEqual(8, group.CellEntities[5].ColumnIndex);
            Assert.AreEqual(8, group.CellEntities[6].RowIndex);
            Assert.AreEqual(6, group.CellEntities[6].ColumnIndex);
            Assert.AreEqual(8, group.CellEntities[7].RowIndex);
            Assert.AreEqual(7, group.CellEntities[7].ColumnIndex);
            Assert.AreEqual(8, group.CellEntities[8].RowIndex);
            Assert.AreEqual(8, group.CellEntities[8].ColumnIndex);

            group = GroupFactory.GetGroup(GroupType.Square, 5, cellCollection);
            Assert.AreEqual(9, group.CellEntities.Count);
            Assert.AreEqual(3, group.CellEntities[0].RowIndex);
            Assert.AreEqual(6, group.CellEntities[0].ColumnIndex);
            Assert.AreEqual(3, group.CellEntities[1].RowIndex);
            Assert.AreEqual(7, group.CellEntities[1].ColumnIndex);
            Assert.AreEqual(3, group.CellEntities[2].RowIndex);
            Assert.AreEqual(8, group.CellEntities[2].ColumnIndex);
            Assert.AreEqual(4, group.CellEntities[3].RowIndex);
            Assert.AreEqual(6, group.CellEntities[3].ColumnIndex);
            Assert.AreEqual(4, group.CellEntities[4].RowIndex);
            Assert.AreEqual(7, group.CellEntities[4].ColumnIndex);
            Assert.AreEqual(4, group.CellEntities[5].RowIndex);
            Assert.AreEqual(8, group.CellEntities[5].ColumnIndex);
            Assert.AreEqual(5, group.CellEntities[6].RowIndex);
            Assert.AreEqual(6, group.CellEntities[6].ColumnIndex);
            Assert.AreEqual(5, group.CellEntities[7].RowIndex);
            Assert.AreEqual(7, group.CellEntities[7].ColumnIndex);
            Assert.AreEqual(5, group.CellEntities[8].RowIndex);
            Assert.AreEqual(8, group.CellEntities[8].ColumnIndex);
        }

        [TestMethod]
        public void RowGroup取得()
        {
            var cells = new[] {
                0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0,
            };
            var cellCollection = new CellCollection(cells);

            var group = GroupFactory.GetGroup(GroupType.Row, 0, cellCollection);
            Assert.AreEqual(9, group.CellEntities.Count);
            Assert.AreEqual(0, group.CellEntities[0].RowIndex);
            Assert.AreEqual(0, group.CellEntities[0].ColumnIndex);
            Assert.AreEqual(0, group.CellEntities[1].RowIndex);
            Assert.AreEqual(1, group.CellEntities[1].ColumnIndex);
            Assert.AreEqual(0, group.CellEntities[2].RowIndex);
            Assert.AreEqual(2, group.CellEntities[2].ColumnIndex);
            Assert.AreEqual(0, group.CellEntities[3].RowIndex);
            Assert.AreEqual(3, group.CellEntities[3].ColumnIndex);
            Assert.AreEqual(0, group.CellEntities[4].RowIndex);
            Assert.AreEqual(4, group.CellEntities[4].ColumnIndex);
            Assert.AreEqual(0, group.CellEntities[5].RowIndex);
            Assert.AreEqual(5, group.CellEntities[5].ColumnIndex);
            Assert.AreEqual(0, group.CellEntities[6].RowIndex);
            Assert.AreEqual(6, group.CellEntities[6].ColumnIndex);
            Assert.AreEqual(0, group.CellEntities[7].RowIndex);
            Assert.AreEqual(7, group.CellEntities[7].ColumnIndex);
            Assert.AreEqual(0, group.CellEntities[8].RowIndex);
            Assert.AreEqual(8, group.CellEntities[8].ColumnIndex);

            group = GroupFactory.GetGroup(GroupType.Row, 8, cellCollection);
            Assert.AreEqual(9, group.CellEntities.Count);
            Assert.AreEqual(8, group.CellEntities[0].RowIndex);
            Assert.AreEqual(0, group.CellEntities[0].ColumnIndex);
            Assert.AreEqual(8, group.CellEntities[1].RowIndex);
            Assert.AreEqual(1, group.CellEntities[1].ColumnIndex);
            Assert.AreEqual(8, group.CellEntities[2].RowIndex);
            Assert.AreEqual(2, group.CellEntities[2].ColumnIndex);
            Assert.AreEqual(8, group.CellEntities[3].RowIndex);
            Assert.AreEqual(3, group.CellEntities[3].ColumnIndex);
            Assert.AreEqual(8, group.CellEntities[4].RowIndex);
            Assert.AreEqual(4, group.CellEntities[4].ColumnIndex);
            Assert.AreEqual(8, group.CellEntities[5].RowIndex);
            Assert.AreEqual(5, group.CellEntities[5].ColumnIndex);
            Assert.AreEqual(8, group.CellEntities[6].RowIndex);
            Assert.AreEqual(6, group.CellEntities[6].ColumnIndex);
            Assert.AreEqual(8, group.CellEntities[7].RowIndex);
            Assert.AreEqual(7, group.CellEntities[7].ColumnIndex);
            Assert.AreEqual(8, group.CellEntities[8].RowIndex);
            Assert.AreEqual(8, group.CellEntities[8].ColumnIndex);

            group = GroupFactory.GetGroup(GroupType.Row, 5, cellCollection);
            Assert.AreEqual(9, group.CellEntities.Count);
            Assert.AreEqual(5, group.CellEntities[0].RowIndex);
            Assert.AreEqual(0, group.CellEntities[0].ColumnIndex);
            Assert.AreEqual(5, group.CellEntities[1].RowIndex);
            Assert.AreEqual(1, group.CellEntities[1].ColumnIndex);
            Assert.AreEqual(5, group.CellEntities[2].RowIndex);
            Assert.AreEqual(2, group.CellEntities[2].ColumnIndex);
            Assert.AreEqual(5, group.CellEntities[3].RowIndex);
            Assert.AreEqual(3, group.CellEntities[3].ColumnIndex);
            Assert.AreEqual(5, group.CellEntities[4].RowIndex);
            Assert.AreEqual(4, group.CellEntities[4].ColumnIndex);
            Assert.AreEqual(5, group.CellEntities[5].RowIndex);
            Assert.AreEqual(5, group.CellEntities[5].ColumnIndex);
            Assert.AreEqual(5, group.CellEntities[6].RowIndex);
            Assert.AreEqual(6, group.CellEntities[6].ColumnIndex);
            Assert.AreEqual(5, group.CellEntities[7].RowIndex);
            Assert.AreEqual(7, group.CellEntities[7].ColumnIndex);
            Assert.AreEqual(5, group.CellEntities[8].RowIndex);
            Assert.AreEqual(8, group.CellEntities[8].ColumnIndex);
        }


        [TestMethod]
        public void ColumnGroup取得()
        {
            var cells = new[] {
                0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0,
            };
            var cellCollection = new CellCollection(cells);

            var group = GroupFactory.GetGroup(GroupType.Column, 0, cellCollection);
            Assert.AreEqual(9, group.CellEntities.Count);
            Assert.AreEqual(0, group.CellEntities[0].RowIndex);
            Assert.AreEqual(0, group.CellEntities[0].ColumnIndex);
            Assert.AreEqual(1, group.CellEntities[1].RowIndex);
            Assert.AreEqual(0, group.CellEntities[1].ColumnIndex);
            Assert.AreEqual(2, group.CellEntities[2].RowIndex);
            Assert.AreEqual(0, group.CellEntities[2].ColumnIndex);
            Assert.AreEqual(3, group.CellEntities[3].RowIndex);
            Assert.AreEqual(0, group.CellEntities[3].ColumnIndex);
            Assert.AreEqual(4, group.CellEntities[4].RowIndex);
            Assert.AreEqual(0, group.CellEntities[4].ColumnIndex);
            Assert.AreEqual(5, group.CellEntities[5].RowIndex);
            Assert.AreEqual(0, group.CellEntities[5].ColumnIndex);
            Assert.AreEqual(6, group.CellEntities[6].RowIndex);
            Assert.AreEqual(0, group.CellEntities[6].ColumnIndex);
            Assert.AreEqual(7, group.CellEntities[7].RowIndex);
            Assert.AreEqual(0, group.CellEntities[7].ColumnIndex);
            Assert.AreEqual(8, group.CellEntities[8].RowIndex);
            Assert.AreEqual(0, group.CellEntities[8].ColumnIndex);

            group = GroupFactory.GetGroup(GroupType.Column, 8, cellCollection);
            Assert.AreEqual(9, group.CellEntities.Count);
            Assert.AreEqual(0, group.CellEntities[0].RowIndex);
            Assert.AreEqual(8, group.CellEntities[0].ColumnIndex);
            Assert.AreEqual(1, group.CellEntities[1].RowIndex);
            Assert.AreEqual(8, group.CellEntities[1].ColumnIndex);
            Assert.AreEqual(2, group.CellEntities[2].RowIndex);
            Assert.AreEqual(8, group.CellEntities[2].ColumnIndex);
            Assert.AreEqual(3, group.CellEntities[3].RowIndex);
            Assert.AreEqual(8, group.CellEntities[3].ColumnIndex);
            Assert.AreEqual(4, group.CellEntities[4].RowIndex);
            Assert.AreEqual(8, group.CellEntities[4].ColumnIndex);
            Assert.AreEqual(5, group.CellEntities[5].RowIndex);
            Assert.AreEqual(8, group.CellEntities[5].ColumnIndex);
            Assert.AreEqual(6, group.CellEntities[6].RowIndex);
            Assert.AreEqual(8, group.CellEntities[6].ColumnIndex);
            Assert.AreEqual(7, group.CellEntities[7].RowIndex);
            Assert.AreEqual(8, group.CellEntities[7].ColumnIndex);
            Assert.AreEqual(8, group.CellEntities[8].RowIndex);
            Assert.AreEqual(8, group.CellEntities[8].ColumnIndex);

            group = GroupFactory.GetGroup(GroupType.Column, 5, cellCollection);
            Assert.AreEqual(9, group.CellEntities.Count);
            Assert.AreEqual(0, group.CellEntities[0].RowIndex);
            Assert.AreEqual(5, group.CellEntities[0].ColumnIndex);
            Assert.AreEqual(1, group.CellEntities[1].RowIndex);
            Assert.AreEqual(5, group.CellEntities[1].ColumnIndex);
            Assert.AreEqual(2, group.CellEntities[2].RowIndex);
            Assert.AreEqual(5, group.CellEntities[2].ColumnIndex);
            Assert.AreEqual(3, group.CellEntities[3].RowIndex);
            Assert.AreEqual(5, group.CellEntities[3].ColumnIndex);
            Assert.AreEqual(4, group.CellEntities[4].RowIndex);
            Assert.AreEqual(5, group.CellEntities[4].ColumnIndex);
            Assert.AreEqual(5, group.CellEntities[5].RowIndex);
            Assert.AreEqual(5, group.CellEntities[5].ColumnIndex);
            Assert.AreEqual(6, group.CellEntities[6].RowIndex);
            Assert.AreEqual(5, group.CellEntities[6].ColumnIndex);
            Assert.AreEqual(7, group.CellEntities[7].RowIndex);
            Assert.AreEqual(5, group.CellEntities[7].ColumnIndex);
            Assert.AreEqual(8, group.CellEntities[8].RowIndex);
            Assert.AreEqual(5, group.CellEntities[8].ColumnIndex);
        }

        [TestMethod]
        public void 指定したCellが含まれるGroupを取得()
        {

            var cells = new[] {
                0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0,
            };
            var cellCollection = new CellCollection(cells);

            var r3c5 = cellCollection.GetCellEntity(32);
            Assert.AreEqual(3, r3c5.RowIndex);
            Assert.AreEqual(5, r3c5.ColumnIndex);

            var groups = GroupFactory.GetGroups(r3c5, cellCollection);
            Assert.AreEqual(3, groups.Count);
            Assert.AreEqual(GroupType.Square, groups[0].GroupType);
            var cellEntities = groups[0].CellEntities;
            Assert.AreEqual(9, cellEntities.Count);
            Assert.AreEqual(3, cellEntities[0].RowIndex);
            Assert.AreEqual(3, cellEntities[0].ColumnIndex);
            Assert.AreEqual(3, cellEntities[1].RowIndex);
            Assert.AreEqual(4, cellEntities[1].ColumnIndex);
            Assert.AreEqual(3, cellEntities[2].RowIndex);
            Assert.AreEqual(5, cellEntities[2].ColumnIndex);
            Assert.AreEqual(4, cellEntities[3].RowIndex);
            Assert.AreEqual(3, cellEntities[3].ColumnIndex);
            Assert.AreEqual(4, cellEntities[4].RowIndex);
            Assert.AreEqual(4, cellEntities[4].ColumnIndex);
            Assert.AreEqual(4, cellEntities[5].RowIndex);
            Assert.AreEqual(5, cellEntities[5].ColumnIndex);
            Assert.AreEqual(5, cellEntities[6].RowIndex);
            Assert.AreEqual(3, cellEntities[6].ColumnIndex);
            Assert.AreEqual(5, cellEntities[7].RowIndex);
            Assert.AreEqual(4, cellEntities[7].ColumnIndex);
            Assert.AreEqual(5, cellEntities[8].RowIndex);
            Assert.AreEqual(5, cellEntities[8].ColumnIndex);


            Assert.AreEqual(GroupType.Row, groups[1].GroupType);
            cellEntities = groups[1].CellEntities;
            Assert.AreEqual(9, cellEntities.Count);
            Assert.AreEqual(3, cellEntities[0].RowIndex);
            Assert.AreEqual(0, cellEntities[0].ColumnIndex);
            Assert.AreEqual(3, cellEntities[1].RowIndex);
            Assert.AreEqual(1, cellEntities[1].ColumnIndex);
            Assert.AreEqual(3, cellEntities[2].RowIndex);
            Assert.AreEqual(2, cellEntities[2].ColumnIndex);
            Assert.AreEqual(3, cellEntities[3].RowIndex);
            Assert.AreEqual(3, cellEntities[3].ColumnIndex);
            Assert.AreEqual(3, cellEntities[4].RowIndex);
            Assert.AreEqual(4, cellEntities[4].ColumnIndex);
            Assert.AreEqual(3, cellEntities[5].RowIndex);
            Assert.AreEqual(5, cellEntities[5].ColumnIndex);
            Assert.AreEqual(3, cellEntities[6].RowIndex);
            Assert.AreEqual(6, cellEntities[6].ColumnIndex);
            Assert.AreEqual(3, cellEntities[7].RowIndex);
            Assert.AreEqual(7, cellEntities[7].ColumnIndex);
            Assert.AreEqual(3, cellEntities[8].RowIndex);
            Assert.AreEqual(8, cellEntities[8].ColumnIndex);

            Assert.AreEqual(GroupType.Column, groups[2].GroupType);
            cellEntities = groups[2].CellEntities;
            Assert.AreEqual(9, cellEntities.Count);
            Assert.AreEqual(0, cellEntities[0].RowIndex);
            Assert.AreEqual(5, cellEntities[0].ColumnIndex);
            Assert.AreEqual(1, cellEntities[1].RowIndex);
            Assert.AreEqual(5, cellEntities[1].ColumnIndex);
            Assert.AreEqual(2, cellEntities[2].RowIndex);
            Assert.AreEqual(5, cellEntities[2].ColumnIndex);
            Assert.AreEqual(3, cellEntities[3].RowIndex);
            Assert.AreEqual(5, cellEntities[3].ColumnIndex);
            Assert.AreEqual(4, cellEntities[4].RowIndex);
            Assert.AreEqual(5, cellEntities[4].ColumnIndex);
            Assert.AreEqual(5, cellEntities[5].RowIndex);
            Assert.AreEqual(5, cellEntities[5].ColumnIndex);
            Assert.AreEqual(6, cellEntities[6].RowIndex);
            Assert.AreEqual(5, cellEntities[6].ColumnIndex);
            Assert.AreEqual(7, cellEntities[7].RowIndex);
            Assert.AreEqual(5, cellEntities[7].ColumnIndex);
            Assert.AreEqual(8, cellEntities[8].RowIndex);
            Assert.AreEqual(5, cellEntities[8].ColumnIndex);
        }
    }
}
