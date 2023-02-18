using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;

namespace Sudoku.WPF.ViewModels
{
    public class InputQuestionViewModel : BindableBase, IDialogAware
    {

        private string _questionText;

        public event Action<IDialogResult> RequestClose;

        public string QuestionText
        {
            get { return _questionText; }
            set { SetProperty(ref _questionText, value); }
        }

        public string Title => "問題入力ダイアログ";

        public DelegateCommand OkCommand { get; }
        public DelegateCommand CancelCommand { get; }

        public InputQuestionViewModel()
        {
            OkCommand = new DelegateCommand(Ok);
            CancelCommand = new DelegateCommand(Cancel);
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }

        private void Ok()
        {
            var result = new DialogResult(ButtonResult.OK);
            result.Parameters.Add(nameof(QuestionText), QuestionText);

            RequestClose?.Invoke(result);
        }

        private void Cancel()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel));
        }
    }
}
