using Sudoku.Domain.ValueObjects;

namespace Sudoku.Domain.Entities
{
    /// <summary>
    /// セルの候補値を管理するためのクラス
    /// </summary>
    public sealed class CandidateCollection
    {
        public static readonly bool CandidateValue = true;
        public static readonly bool NotCandidateValue = false;

        private readonly List<bool> _candidates;
        /// <summary>
        /// 候補値情報
        /// </summary>

        public IReadOnlyList<bool> Candidates => _candidates.AsReadOnly();

        /// <summary>
        /// コンストラクタ
        /// 指定された情報で全ての候補値を初期化します。
        /// </summary>
        /// <param name="isCandidate">候補値を含むか</param>
        public CandidateCollection(bool isCandidate)
        {
            _candidates = new List<bool>();
            for (int i = 0; i < 9; i++)
            {
                _candidates.Add(isCandidate);
            }
        }

        /// <summary>
        /// コンストラクタ
        /// 指定されたリストで初期化します。
        /// </summary>
        /// <param name="candidates">候補値リスト</param>
        public CandidateCollection(IReadOnlyList<bool> candidates)
        {
            _candidates = new List<bool>();
            foreach (var candidate in candidates)
            {
                _candidates.Add(candidate);
            }
        }

        /// <summary>
        /// 消込処理
        /// 指定された値の候補値を候補から外します
        /// </summary>
        /// <param name="cellValue">候補値として外す値</param>
        public void Reconcil(CellValue cellValue)
        {
            _candidates[GetIndex(cellValue)] = NotCandidateValue;
        }

        /// <summary>
        /// 候補値が一つに絞られているかチェック
        /// </summary>
        /// <returns>候補値が特定されている</returns>
        public bool IsOnlyOneCandidate()
        {
            var count = _candidates.Where(x => x.Equals(CandidateValue)).Count();
            return count == 1;
        }

        /// <summary>
        /// 特定された候補値を取得
        /// はじめに候補として取得した値を返す
        /// 基本的には、候補値が一つに絞られたときに実行すること
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>

        public CellValue GetCellValue()
        {
            var index = 0;
            foreach (var candidate in _candidates)
            {
                if (candidate)
                {
                    return GetCellValue(index);
                }
                index++;
            }
            throw new Exception();
        }

        /// <summary>
        /// 候補値全てを候補から外す処理
        /// </summary>
        public void Off()
        {
            for (int i = 0; i < _candidates.Count; i++)
            {
                _candidates[i] = NotCandidateValue;
            }
        }

        /// <summary>
        /// 候補値すべて候補とする処理
        /// </summary>
        public void On()
        {
            for (int i = 0; i < _candidates.Count; i++)
            {
                _candidates[i] = CandidateValue;
            }
        }

        /// <summary>
        /// 指定された候補値が候補に含まれているか確認
        /// </summary>
        /// <param name="cellValue">確認する候補値</param>
        /// <returns></returns>
        public bool Contains(CellValue cellValue)
        {
            return Candidates[GetIndex(cellValue)];
        }

        /// <summary>
        /// 候補値となっている数を取得
        /// </summary>
        /// <returns></returns>
        public int GetCandidateCount()
        {
            return Candidates.Where(x => x).Count();
        }

        /// <summary>
        /// 指定された候補情報と一致するか確認
        /// </summary>
        /// <param name="candidateCollection"></param>
        /// <returns></returns>
        public bool EqualsCandidates(CandidateCollection candidateCollection)
        {
            for (int i = 0; i < Candidates.Count; ++i)
            {
                if (Candidates[i] != candidateCollection.Candidates[i])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 指定された候補値情報と一致する候補を除外する処理
        /// </summary>
        /// <param name="candidateCollection"></param>
        public void Exclude(CandidateCollection candidateCollection)
        {
            for (int i = 0; i < Candidates.Count; ++i)
            {
                if (candidateCollection.Candidates[i])
                {
                    _candidates[i] = NotCandidateValue;
                }
            }
        }

        /// <summary>
        /// 指定された値から候補情報のIndexを取得
        /// TODO:作成するクラスが問題ないか確認
        /// </summary>
        /// <param name="cellValue"></param>
        /// <returns></returns>
        private static int GetIndex(CellValue cellValue)
        {
            return cellValue.Value - 1;
        }

        /// <summary>
        /// 指定された候補情報のIndexから値を取得
        /// TODO:作成するクラスが問題ないか確認
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private static CellValue GetCellValue(int index)
        {
            return new CellValue(index + 1);
        }
    }
}
