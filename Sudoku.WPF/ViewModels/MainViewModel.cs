using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace Sudoku.WPF.ViewModels
{
    public class MainViewModel : BindableBase
    {


        private ObservableCollection<MainViewModelCell> _cells = new ObservableCollection<MainViewModelCell>();
        public ObservableCollection<MainViewModelCell> Cells
        {
            get => _cells;
            set => SetProperty(ref _cells, value);
        }

        private MainViewModelCell _selectedCell;
        public MainViewModelCell SelectedCell
        {
            get => _selectedCell;
            set
            {
                if (_selectedCell != null)
                {
                    _selectedCell.IsSelected = false;
                }
                if (SetProperty(ref _selectedCell, value))
                {
                    if (value != null)
                    {
                        value.IsSelected = true;
                    }
                }
            }
        }


        public MainViewModel()
        {
            for (int row = 0; row < 9; ++row)
            {
                for (int col = 0; col < 9; ++col)
                {
                    var left = col == 0;
                    var top = row == 0;
                    var right = (col + 1) % 3 == 0;
                    var bottom = (row + 1) % 3 == 0;
                    int number = 0;
                    Cells.Add(new MainViewModelCell(number, row, col, left, top, right, bottom));
                }
            }
        }
    }
}
