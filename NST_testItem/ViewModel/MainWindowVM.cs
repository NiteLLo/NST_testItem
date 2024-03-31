using Caliburn.Micro;
using NST_testItem.Model;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace NST_testItem.ViewModel
{
    /// <summary>
    /// Класс модели-представления для главного(единственного) окна
    /// </summary>
    class MainWindowVM : BaseVM
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        public MainWindowVM()
        {
            var dw = new DataWork();
            FunctionModels = new BindableCollection<FunctionModel>(dw.GetFunctionList());
            LoadData();
        }

      
        #region Collection
        private BindableCollection<FunctionModel> functionModels;
        /// <summary>
        /// Коллкция моделей функции
        /// </summary>
        public BindableCollection<FunctionModel> FunctionModels
        {
            get { return functionModels; }
            set { functionModels = value; NotifyPropertyChanged(nameof(FunctionModels)); }
        }

        private BindableCollection<string> functionRankNameList;
        /// <summary>
        /// Коллекция степеней функции
        /// </summary>
        public BindableCollection<string> FunctionRankNameList
        { 
            get { return functionRankNameList; }
            set { functionRankNameList = value; NotifyPropertyChanged(nameof(FunctionRankNameList)); }
        }

        private BindableCollection<int> coeficientCList;
        /// <summary>
        /// Коллекция коэффициентов c
        /// </summary>
        public BindableCollection<int> CoeficientCList
        {
            get { return coeficientCList; }
            set { coeficientCList = value; NotifyPropertyChanged(nameof(CoeficientCList)); }
        }      
        #endregion
        #region Command
        private RelayCommand currentCoeficientCSelectionChanged;
        /// <summary>
        /// Команда, реагирующая на изменение текущего коэффициента c
        /// </summary>
        public RelayCommand CurrentCoeficientCSelectionChanged
        {
            get
            {
                return currentCoeficientCSelectionChanged ?? new RelayCommand(obj =>
                {
                    FunctionModels.Refresh();
                });
            }
        }

        private RelayCommand functionRankSelectionChanged;
        /// <summary>
        /// Команда, реагирующая на изменение текущей степени функции
        /// </summary>
        public RelayCommand FunctionRankSelectionChanged
        {
            get
            {
                return functionRankSelectionChanged ?? new RelayCommand(obj =>
                {
                    int tb = (int)obj;
                    var dw = new DataWork();
                    FunctionModels = dw.UpdateCoeficientC(FunctionModels, tb + 1, RowIndex);
                    CoeficientCList = FunctionModels[RowIndex].CoefficientCList;
                    CoefficientA = FunctionModels[RowIndex].FunctionToCoefficientA[CurrentFunctionRankName];
                    CoefficientB = FunctionModels[RowIndex].FunctionToCoefficientB[CurrentFunctionRankName];
                    CurrentCoeficientC = CoeficientCList[FunctionModels[RowIndex].FunctionToCoefficientC[CurrentFunctionRankName]];
                    FunctionModels.Refresh();
                });
            }
        }

        private RelayCommand unknownChanged;
        /// <summary>
        /// Команда, реагирующая на изменение неизвестных x и y
        /// </summary>
        public RelayCommand UnknownChanged
        {
            get
            {
                return unknownChanged ?? new RelayCommand(obj =>
                {
                    FunctionModels.Refresh();
                });
            }
        }

        private RelayCommand selectedCellsChanged;
        /// <summary>
        /// Команда, реагирующая на изменение выбранной строки
        /// </summary>
        public RelayCommand SelectedCellsChanged
        {
            get
            {
                return selectedCellsChanged ?? new RelayCommand(obj =>
                {
                    int i = (int)obj;
                    RowIndex = i;
                    CurrentFunctionRankName = FunctionModels[RowIndex].CurrentFunctionRankName;
                    CurrentCoeficientC = FunctionModels[RowIndex].CurrentCoefficientC;
                    LoadData();
                    FunctionModels.Refresh();
                });
            }
        }

        private RelayCommand addNewRow;
        /// <summary>
        /// Команда, реагирующая на нажатие кнопки для создания новой строки в таблицу данных
        /// </summary>
        public RelayCommand AddNewRow
        {
            get
            {
                return addNewRow ?? new RelayCommand(obj =>
                {
                    if (FunctionModels.Count <= 10)
                    {
                        var dw = new DataWork();
                        FunctionModels = dw.AddFunction(FunctionModels);
                        CurrentCoeficientC = FunctionModels[RowIndex].CurrentCoefficientC;
                        FunctionModels.Refresh();
                    }
                });
            }
        }

        #endregion
        #region Method
        /// <summary>
        /// Метод загрузки данных
        /// </summary>
        private void LoadData()
        {
            FunctionRankNameList = FunctionModels[RowIndex].FunctionRankNameList;
            CoeficientCList = FunctionModels[RowIndex].CoefficientCList;
            CoefficientA = FunctionModels[RowIndex].CoefficientA.ToString();
            CoefficientB = FunctionModels[RowIndex].CoefficientB.ToString();
        }
        #endregion
        #region Prop
        #region Coefficient
        private string coefficientA = "0";
        /// <summary>
        /// Публичное свойство коэфициента a
        /// </summary>
        public string CoefficientA
        {
            get { return coefficientA; }
            set
            {
                coefficientA = Regex.Replace(value, @"[^0-9]+", new string(""));
                FunctionModels[RowIndex].CoefficientA = CoefficientA;
                if (CurrentFunctionRankName != null) FunctionModels[RowIndex].FunctionToCoefficientA[CurrentFunctionRankName] = CoefficientA;
                FunctionModels.Refresh();
                NotifyPropertyChanged(nameof(CoefficientA));
            }
        }

        private string coefficientB = "0";
        /// <summary>
        /// Публичное свойство коэфициента b
        /// </summary>
        public string CoefficientB
        {
            get { return coefficientB; }
            set
            {
                coefficientB = Regex.Replace(value, @"[^0-9]+", new string("")); ;
                FunctionModels[RowIndex].CoefficientB = CoefficientB;
                if (CurrentFunctionRankName != null) FunctionModels[RowIndex].FunctionToCoefficientB[CurrentFunctionRankName] = CoefficientB;
                FunctionModels.Refresh();
                NotifyPropertyChanged(nameof(CoefficientB));
            }
        }

        private int currentCoeficientC;
        /// <summary>
        /// Свойство текущего коэффициента c
        /// </summary>
        public int CurrentCoeficientC
        {
            get { return currentCoeficientC; }
            set
            {
                currentCoeficientC = value;
                FunctionModels[RowIndex].CurrentCoefficientC = CurrentCoeficientC;
                if (CurrentFunctionRankName != null) FunctionModels[RowIndex].FunctionToCoefficientC[CurrentFunctionRankName] = (CurrentCoeficientC % 9) - 1;
                NotifyPropertyChanged(nameof(CurrentCoeficientC));
                FunctionModels.Refresh();
            }
        }
        #endregion
        private int rowIndex;
        /// <summary>
        /// Свойство текущего индекса строки
        /// </summary>
        public int RowIndex
        {
            get { return rowIndex; }
            set { rowIndex = value; }
        }

        private string currentFunctionRankName;
        /// <summary>
        /// Свойство текущей степени функции
        /// </summary>
        public string CurrentFunctionRankName
        {
            get { return currentFunctionRankName; }
            set
            {
                currentFunctionRankName = value;
                FunctionModels[RowIndex].CurrentFunctionRankName = CurrentFunctionRankName;
                NotifyPropertyChanged(nameof(CurrentFunctionRankName));
                FunctionModels.Refresh();
            }
        }
        #endregion         
       
    }
}
