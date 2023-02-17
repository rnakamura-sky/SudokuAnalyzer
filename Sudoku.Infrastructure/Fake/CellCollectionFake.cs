using Sudoku.Domain.Entities;
using Sudoku.Domain.Repositories;

namespace Sudoku.Infrastructure.Fake
{
    /// <summary>
    /// サンプル用CellCollectionリポジトリクラス
    /// </summary>
    public class CellCollectionFake : ICellCollectionRepository
    {
        /// <summary>
        /// 問題を取得する
        /// </summary>
        /// <returns></returns>
        public CellCollection GetCellCollection()
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
            return cellCollection;
        }
    }
}
