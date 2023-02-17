using Sudoku.Domain.Entities;

namespace Sudoku.Domain.Repositories
{
    /// <summary>
    /// Sudoku問題取得リポジトリ
    /// </summary>
    public interface ICellCollectionRepository
    {
        /// <summary>
        /// 問題(CellCollection)を取得する
        /// </summary>
        /// <returns></returns>
        CellCollection GetCellCollection();
    }
}
