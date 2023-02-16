using Sudoku.WPF.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Sudoku.WPF.Views.DataTemplateSelectors
{
    public class CellTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ConfirmTemplate { get; set; }
        public DataTemplate CandidateTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var cell = item as MainViewModelCell;
            if (cell is null)
            {
                return CandidateTemplate;
            }

            if (cell.IsConfirm)
            {
                return ConfirmTemplate;
            }
            return CandidateTemplate;
        }
    }
}
