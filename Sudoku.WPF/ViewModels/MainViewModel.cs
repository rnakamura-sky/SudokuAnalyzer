using Prism.Commands;
using Prism.Mvvm;
using Sudoku.Domain.Entities;
using Sudoku.Domain.Logics;
using Sudoku.Infrastructure.Fake;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Sudoku.WPF.ViewModels
{
    public class MainViewModel : BindableBase
    {

        /// <summary>
        /// Cellリスト
        /// </summary>
        private ObservableCollection<MainViewModelCell> _cells = new ObservableCollection<MainViewModelCell>();

        /// <summary>
        /// Cellリスト
        /// </summary>
        public ObservableCollection<MainViewModelCell> Cells
        {
            get => _cells;
            set => SetProperty(ref _cells, value);
        }

        /// <summary>
        /// 選択中のCell
        /// </summary>
        private MainViewModelCell _selectedCell;

        /// <summary>
        /// 選択中のCell
        /// </summary>
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

        /// <summary>
        /// リセットコマンド
        /// </summary>
        public DelegateCommand ResetCommand { get; }

        /// <summary>
        /// 消込コマンド
        /// </summary>
        public DelegateCommand ReconcilCommand { get; }

        /// <summary>
        /// ペア消込コマンド
        /// </summary>
        public DelegateCommand ReconcilPairCommand { get; }

        /// <summary>
        /// 候補値決定コマンド
        /// </summary>
        public DelegateCommand DecideCellsCommand { get; }

        /// <summary>
        /// グループ内候補値決定コマンド
        /// </summary>
        public DelegateCommand DecideCellInGroupsCommand { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainViewModel()
        {
            var _cellCollectionRepository = new CellCollectionFake();
            var cellCollection = _cellCollectionRepository.GetCellCollection();

            SetCells(cellCollection);

            ResetCommand = new DelegateCommand(ExecuteResetCommand);
            ReconcilCommand = new DelegateCommand(ExecuteReconcilCommand);
            ReconcilPairCommand = new DelegateCommand(ExecuteReconcilPairCommand);
            DecideCellsCommand = new DelegateCommand(ExecuteDecideCellsCommand);
            DecideCellInGroupsCommand = new DelegateCommand(ExecuteDecideCellInGroupsCommand);
        }

        /// <summary>
        /// ViewModelに設定されているCell一覧取得
        /// </summary>
        /// <returns></returns>
        public CellCollection GetCellCollection()
        {
            var cells = new List<CellEntity>();
            foreach(var cell in Cells)
            {
                cells.Add(cell.GetCellEntity());
            }
            return new CellCollection(cells);
        }

        /// <summary>
        /// リセットコマンド実行
        /// </summary>
        private void ExecuteResetCommand()
        {
            var cellCollection = GetCellCollection();
            cellCollection.Reset();
            SetCells(cellCollection);
            Debug.WriteLine("Resetしました");
        }

        /// <summary>
        /// 消込コマンド実行
        /// </summary>
        private void ExecuteReconcilCommand()
        {
            var cellCollection = GetCellCollection();
            var logic = new SolutionLogic(cellCollection);

            logic.Reconcil();

            SetCells(cellCollection);
            Debug.WriteLine("Reconcilを実行しました");
        }

        /// <summary>
        /// ペア消込コマンド実行
        /// </summary>
        private void ExecuteReconcilPairCommand()
        {
            var cellCollection = GetCellCollection();
            var logic = new SolutionLogic(cellCollection);

            logic.ReconcilPair();

            SetCells(cellCollection);
            Debug.WriteLine("ReconcilPairを実行しました");
        }

        /// <summary>
        /// 候補値決定コマンド実行
        /// </summary>
        private void ExecuteDecideCellsCommand()
        {
            var cellCollection = GetCellCollection();
            var logic = new SolutionLogic(cellCollection);

            logic.DecideCells();

            SetCells(cellCollection);
            Debug.WriteLine("DecideCellsを実行しました");
        }

        /// <summary>
        /// グループ内候補値決定コマンド実行
        /// </summary>
        private void ExecuteDecideCellInGroupsCommand()
        {
            var cellCollection = GetCellCollection();
            var logic = new SolutionLogic(cellCollection);

            logic.DecideCellInGroups();

            SetCells(cellCollection);
            Debug.WriteLine("DecideCellInGroupsを実行しました");
        }

        /// <summary>
        /// セル情報設定
        /// </summary>
        /// <param name="cellCollection"></param>
        private void SetCells(CellCollection cellCollection)
        {
            Cells.Clear();
            foreach (var cell in cellCollection.GetCells())
            {
                Cells.Add(new MainViewModelCell(cell));
            }
        }
    }
}
