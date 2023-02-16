using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace Sudoku.WPF.ViewModels
{
    public class MainViewModelCell : BindableBase
    {
        private string _confirmValueText;
        public string ConfirmValueText
        {
            get => _confirmValueText;
            set => SetProperty(ref _confirmValueText, value);
        }

        private int _confirmValue;
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

        public bool IsConfirm
        {
            get => ConfirmValue > 0;
        }

        private bool _isFixed;
        public bool IsFixed
        {
            get => _isFixed;
            private set => _isFixed = value;
        }

        private ObservableCollection<bool> _candidates = new ObservableCollection<bool>();
        public ObservableCollection<bool> Candidates
        {
            get => _candidates;
            set => SetProperty(ref _candidates, value);
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }

        public int RowIndex { get; }
        public int ColumnIndex { get; }
        public bool LeftLine { get; }
        public bool TopLine { get; }
        public bool RightLine { get; }
        public bool BottomLine { get; }

        public DelegateCommand<object> ActionCommand { get; }


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
