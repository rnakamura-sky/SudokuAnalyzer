using Sudoku.Domain.ValueObjects;

namespace Sudoku.Domain.Entities
{
    /// <summary>
    /// グループ作成ファクトリークラス
    /// </summary>
    public class GroupFactory
    {
        /// <summary>
        /// 設定されうるグループまとまりリストを取得
        /// </summary>
        /// <param name="cellCollection"></param>
        /// <returns></returns>
        public static IReadOnlyList<GroupCollection> GetGroupCollections(CellCollection cellCollection)
        {
            var result = new List<GroupCollection>();
            foreach (var groupType in GroupType.ToList())
            {
                result.Add(GetGroupCollection(groupType, cellCollection));
            }
            return result.AsReadOnly();
        }

        /// <summary>
        /// 特定のGroupTypeのグループリストを取得
        /// </summary>
        /// <param name="groupType"></param>
        /// <param name="cellCollection"></param>
        /// <returns></returns>

        public static GroupCollection GetGroupCollection(GroupType groupType, CellCollection cellCollection)
        {
            var groups = new List<Group>();
            for (int i = 0; i < 9; ++i)
            {
                groups.Add(GetGroup(groupType, i, cellCollection));
            }

            return new GroupCollection(groups);
        }

        /// <summary>
        /// 特定のGroupTypeの特定のグループIdのグループを取得
        /// </summary>
        /// <param name="groupType"></param>
        /// <param name="groupId"></param>
        /// <param name="cellCollection"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static Group GetGroup(GroupType groupType, int groupId, CellCollection cellCollection)
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

        /// <summary>
        /// 指定されたCellが含まれるグループリストを取得
        /// </summary>
        /// <param name="cellEntity"></param>
        /// <param name="cellCollection"></param>
        /// <returns></returns>
        public static IReadOnlyList<Group> GetGroups(CellEntity cellEntity, CellCollection cellCollection)
        {
            var result = new List<Group>();
            foreach (var groupType in GroupType.ToList())
            {
                result.Add(GetGroup(groupType, cellEntity, cellCollection));
            }
            return result.AsReadOnly();
        }

        /// <summary>
        /// 指定されたGroupTypeで指定されたCellが含まれるグループリストを取得
        /// </summary>
        /// <param name="groupType"></param>
        /// <param name="cellEntity"></param>
        /// <param name="cellCollection"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
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

    /// <summary>
    /// 四角形グループ作成クラス
    /// </summary>
    public class SquareGroupCreater : IGroupCreater
    {
        /// <summary>
        /// グループを取得する
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="cellCollection"></param>
        /// <returns></returns>
        public Group GetGroup(int groupId, CellCollection cellCollection)
        {
            var result = new List<CellEntity>();

            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    var row = (groupId / 3) * 3 + i;
                    var col = (groupId % 3) * 3 + j;
                    result.Add(cellCollection.GetCellEntity(row, col));
                }
            }
            return new Group(GroupType.Square, groupId, result);
        }

        /// <summary>
        /// 指定されたCellが含まれるグループを取得する
        /// </summary>
        /// <param name="cellEntity"></param>
        /// <param name="cellCollection"></param>
        /// <returns></returns>
        public Group GetGroup(CellEntity cellEntity, CellCollection cellCollection)
        {
            var rowIndex = cellEntity.RowIndex / 3;
            var columnIndex = cellEntity.ColumnIndex / 3;
            var groupId = rowIndex * 3 + columnIndex;
            return GetGroup(groupId, cellCollection);
        }
    }

    public class RowGroupCreater : IGroupCreater
    {
        /// <summary>
        /// グループを取得する
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="cellCollection"></param>
        /// <returns></returns>
        public Group GetGroup(int groupId, CellCollection cellCollection)
        {
            var result = new List<CellEntity>();

            for (int i = 0; i < 9; ++i)
            {
                var row = groupId;
                var col = i;
                result.Add(cellCollection.GetCellEntity(row, col));
            }

            return new Group(GroupType.Row, groupId, result);
        }

        /// <summary>
        /// 指定されたCellが含まれるグループを取得する
        /// </summary>
        /// <param name="cellEntity"></param>
        /// <param name="cellCollection"></param>
        /// <returns></returns>
        public Group GetGroup(CellEntity cellEntity, CellCollection cellCollection)
        {
            var groupId = cellEntity.RowIndex;
            return GetGroup(groupId, cellCollection);
        }
    }

    public class ColumnGroupCreater : IGroupCreater
    {
        /// <summary>
        /// グループを取得する
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="cellCollection"></param>
        /// <returns></returns>
        public Group GetGroup(int groupId, CellCollection cellCollection)
        {
            var result = new List<CellEntity>();

            for (int i = 0; i < 9; ++i)
            {
                var row = i;
                var col = groupId;
                result.Add(cellCollection.GetCellEntity(row, col));
            }

            return new Group(GroupType.Column, groupId, result);
        }

        /// <summary>
        /// 指定されたCellが含まれるグループを取得する
        /// </summary>
        /// <param name="cellEntity"></param>
        /// <param name="cellCollection"></param>
        /// <returns></returns>
        public Group GetGroup(CellEntity cellEntity, CellCollection cellCollection)
        {
            var groupId = cellEntity.ColumnIndex;
            return GetGroup(groupId, cellCollection);
        }
    }
}
