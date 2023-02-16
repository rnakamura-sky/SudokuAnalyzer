using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Sudoku.WPF.ViewModels
{
    public class MainViewModel : BindableBase
    {

        private ObservableCollection<ObservableCollection<MainViewModelCell>> _dataTable;

        public ObservableCollection<ObservableCollection<MainViewModelCell>> DataTable
        {
            get => _dataTable;
            set => SetProperty(ref _dataTable, value);
        }

        public MainViewModel()
        {
            DataTable = new ObservableCollection<ObservableCollection<MainViewModelCell>>();

            for (int i = 0; i < 9; ++i)
            {
                var row = new ObservableCollection<MainViewModelCell>();
                for (int j = 0; j < 9; ++j)
                {
                    var number = j + 1;
                    row.Add(new MainViewModelCell(number));
                }
                DataTable.Add(row);
            }
        }
    }
}
