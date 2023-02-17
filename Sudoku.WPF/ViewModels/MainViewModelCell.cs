using Prism.Commands;
using Prism.Mvvm;
using Sudoku.Domain.Entities;
using System.Collections.ObjectModel;
using System.Linq;

namespace Sudoku.WPF.ViewModels
{
    /// <summary>
    /// CellのViewModel
    /// </summary>
    public class MainViewModelCell : BindableBase
    {
        /// <summary>
        /// 決定値テキスト
        /// </summary>
        private string _confirmValueText;

        /// <summary>
        /// 決定値テキスト
        /// </summary>
        public string ConfirmValueText
        {
            get => _confirmValueText;
            set => SetProperty(ref _confirmValueText, value);
        }

        /// <summary>
        /// 決定値
        /// </summary>
        private int _confirmValue;

        /// <summary>
        /// 決定値
        /// </summary>
        public int ConfirmValue
        {
            get => _confirmValue;
            set
            {
                if (SetProperty(ref _confirmValue, value))
                {
                    ConfirmValueText = value.ToString();
                    RaisePropertyChanged(nameof(IsConfirm));

                    if (value > 0)
                    {
                        for (int i = 0; i < Candidates.Count; ++i)
                        {
                            if (i + 1 == value)
                            {
                                continue;
                            }
                            Candidates[i] = false;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 決定済み判定
        /// </summary>

        public bool IsConfirm
        {
            get => ConfirmValue > 0;
        }

        /// <summary>
        /// 固定値判定
        /// </summary>
        private bool _isFixed;

        /// <summary>
        /// 固定値判定
        /// </summary>
        public bool IsFixed
        {
            get => _isFixed;
            private set => _isFixed = value;
        }

        /// <summary>
        /// 候補値リスト
        /// </summary>
        private ObservableCollection<bool> _candidates = new ObservableCollection<bool>();

        /// <summary>
        /// 候補値リスト
        /// </summary>
        public ObservableCollection<bool> Candidates
        {
            get => _candidates;
            set => SetProperty(ref _candidates, value);
        }

        /// <summary>
        /// 選択状態
        /// </summary>
        private bool _isSelected;

        /// <summary>
        /// 選択状態
        /// </summary>
        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }

        /// <summary>
        /// 行座標
        /// </summary>
        public int RowIndex { get; }

        /// <summary>
        /// 列座標
        /// </summary>
        public int ColumnIndex { get; }

        /// <summary>
        /// 左枠線有無
        /// </summary>
        public bool LeftLine { get; }

        /// <summary>
        /// 上枠線有無
        /// </summary>
        public bool TopLine { get; }

        /// <summary>
        /// 右枠線有無
        /// </summary>
        public bool RightLine { get; }

        /// <summary>
        /// 下枠線有無
        /// </summary>
        public bool BottomLine { get; }

        /// <summary>
        /// 候補値消込コマンド
        /// </summary>
        public DelegateCommand<object> ActionCommand { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="cellEntity"></param>
        public MainViewModelCell(CellEntity cellEntity)
        {
            ConfirmValue = cellEntity.Value.Value;
            IsFixed = cellEntity.IsFixed;
            foreach (var candidate in cellEntity.CandidateCollection.Candidates)
            {
                Candidates.Add(candidate);
            }
            RowIndex = cellEntity.RowIndex;
            ColumnIndex = cellEntity.ColumnIndex;

            LeftLine = ColumnIndex == 0;
            RightLine = (ColumnIndex + 1) % 3 == 0;
            TopLine = RowIndex == 0;
            BottomLine = (RowIndex + 1) % 3 == 0;

            IsSelected = false;

            ActionCommand = new DelegateCommand<object>(ActionCommandExecute);

        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="number"></param>
        /// <param name="rowIndex"></param>
        /// <param name="columnIndex"></param>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
        public MainViewModelCell(int number, int rowIndex, int columnIndex, bool left, bool top, bool right, bool bottom)
        {
            ConfirmValue = number;

            if (number > 0)
            {
                IsFixed = true;
            }
            else
            {
                IsFixed = false;
                for (int i = 0; i < 9; ++i)
                {
                    Candidates.Add(true);
                }
            }

            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
            LeftLine = left;
            TopLine = top;
            RightLine = right;
            BottomLine = bottom;

            IsSelected = false;

            ActionCommand = new DelegateCommand<object>(ActionCommandExecute);
        }

        /// <summary>
        /// 設定されているCellEntity取得
        /// </summary>
        /// <returns></returns>
        public CellEntity GetCellEntity()
        {
            return new CellEntity(
                ConfirmValue,
                RowIndex,
                ColumnIndex,
                IsFixed,
                Candidates.ToList());
        }

        /// <summary>
        /// 候補値消込コマンド実行
        /// </summary>
        /// <param name="number"></param>
        private void ActionCommandExecute(object number)
        {
            int result;
            if (int.TryParse((string)number, out result))
            {
                int index = result - 1;
                Candidates[index] = !Candidates[index];
            }
        }
    }
}
