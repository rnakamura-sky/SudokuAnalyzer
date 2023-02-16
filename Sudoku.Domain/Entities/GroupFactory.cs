using Sudoku.Domain.ValueObjects;

namespace Sudoku.Domain.Entities
{
    public class GroupFactory
    {
        public static IReadOnlyList<GroupCollection> GetGroupCollections(CellCollection cellCollection)
        {
            var result = new List<GroupCollection>();
            foreach (var groupType in GroupType.ToList())
            {
                result.Add(GetGroupCollection(groupType, cellCollection));
            }
            return result.AsReadOnly();
        }

        private static GroupCollection GetGroupCollection(GroupType groupType, CellCollection cellCollection)
        {
            var groups = new List<Group>();
            for (int i = 0; i < 9; ++i)
            {
                groups.Add(GetGroup(groupType, i, cellCollection));
            }

            return new GroupCollection(groups);
        }

        private static Group GetGroup(GroupType groupType, int groupId, CellCollection cellCollection)
        {
            if (groupType == GroupType.Square)
            {
                return new SquareGroupCreater().GetGroup(groupId, cellCollection);
            }
            if (groupType == GroupType.Row)
            {
                return new RowGroupCreater().GetGroup(groupId, cellCollection);
            }
            if (groupType == GroupType.Column)
            {
                return new ColumnGroupCreater().GetGroup(groupId, cellCollection);
            }


            throw new NotImplementedException();
        }

        public static IReadOnlyList<Group> GetGroups(CellEntity cellEntity, CellCollection cellCollection)
        {
            var result = new List<Group>();
            foreach (var groupType in GroupType.ToList())
            {
                result.Add(GetGroup(groupType, cellEntity, cellCollection));
            }
            return result.AsReadOnly();
        }

        private static Group GetGroup(GroupType groupType, CellEntity cellEntity, CellCollection cellCollection)
        {
            if (groupType == GroupType.Square)
            {
                return new SquareGroupCreater().GetGroup(cellEntity, cellCollection);
            }
            if (groupType == GroupType.Row)
            {
                return new RowGroupCreater().GetGroup(cellEntity, cellCollection);
            }
            if (groupType == GroupType.Column)
            {
                return new ColumnGroupCreater().GetGroup(cellEntity, cellCollection);
            }


            throw new NotImplementedException();
        }
    }

    public interface IGroupCreater
    {
        Group GetGroup(int groupId, CellCollection cellCollection);
        Group GetGroup(CellEntity cellEntity, CellCollection cellCollection);
    }

    public class SquareGroupCreater : IGroupCreater
    {
        public Group GetGroup(int groupId, CellCollection cellCollection)
        {
            var result = new List<CellEntity>();

            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    var row = (groupId / 3) + i;
                    var col = (groupId % 3) + j;
                    var index = row * 9 + col;
                    result.Add(cellCollection.Cells[index]);
                }
            }

            return new Group(GroupType.Square, groupId, result);
        }

        public Group GetGroup(CellEntity cellEntity, CellCollection cellCollection)
        {
            var rowIndex = cellEntity.RowIndex % 3;
            var columnIndex = cellEntity.ColumnIndex % 3;
            var groupId = rowIndex * 3 + columnIndex;
            return GetGroup(groupId, cellCollection);
        }
    }

    public class RowGroupCreater : IGroupCreater
    {
        public Group GetGroup(int groupId, CellCollection cellCollection)
        {
            var result = new List<CellEntity>();

            for (int i = 0; i < 9; ++i)
            {
                var row = groupId;
                var col = i;
                var index = row * 9 + col;
                result.Add(cellCollection.Cells[index]);
            }

            return new Group(GroupType.Row, groupId, result);
        }

        public Group GetGroup(CellEntity cellEntity, CellCollection cellCollection)
        {
            var groupId = cellEntity.RowIndex;
            return GetGroup(groupId, cellCollection);
        }
    }


    public class ColumnGroupCreater : IGroupCreater
    {
        public Group GetGroup(int groupId, CellCollection cellCollection)
        {
            var result = new List<CellEntity>();

            for (int i = 0; i < 9; ++i)
            {
                var row = i;
                var col = groupId;
                var index = row * 9 + col;
                result.Add(cellCollection.Cells[index]);
            }

            return new Group(GroupType.Column, groupId, result);
        }

        public Group GetGroup(CellEntity cellEntity, CellCollection cellCollection)
        {
            var groupId = cellEntity.ColumnIndex;
            return GetGroup(groupId, cellCollection);
        }
    }
}
