using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku.WPF.ViewModels
{
    public class MainViewModelCell : BindableBase
    {
        private int _value;
        public int Value
        {
            get => _value;
            set => SetProperty(ref _value, value);
        }

        public MainViewModelCell(int value)
        {
            Value = value;
        }
    }
}
