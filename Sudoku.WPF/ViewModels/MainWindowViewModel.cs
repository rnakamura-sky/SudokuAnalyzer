using Prism.Mvvm;
using Prism.Regions;
using Sudoku.WPF.Views;

namespace Sudoku.WPF.ViewModels
{
    /// <summary>
    /// メインWindowViewModel
    /// </summary>
    public class MainWindowViewModel : BindableBase
    {
        /// <summary>
        /// RegionManager
        /// </summary>
        private readonly IRegionManager _regionManager;

        /// <summary>
        /// タイトル
        /// </summary>
        private string _title = "Sudoku Analyzer";

        /// <summary>
        /// タイトル
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="regionManager"></param>

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(MainView));

        }
    }
}
