using Caliburn.Micro;
using System.Text.RegularExpressions;

namespace NST_testItem.Model
{
    /// <summary>
    /// Класс модели функции со всем её свойствами
    /// </summary>
    public class FunctionModel
    {
        public int Id { get; set; }

        private ConvertFunctionRankNameToFunctionRank converter = new ConvertFunctionRankNameToFunctionRank();

        public BindableCollection<string> FunctionRankNameList { get; set; }

        private string currentFunctionRankName;

        public string CurrentFunctionRankName 
        { 
            get {  return currentFunctionRankName; } 
            set {  currentFunctionRankName = value; x = FunctionToUnknownX[CurrentFunctionRankName]; y = FunctionToUnknownX[CurrentFunctionRankName]; } 
        }

        public int FunctionRank 
        { 
            get 
            {
                return converter.Convert(CurrentFunctionRankName);
            }
        }

        private string x;

        public string X { get { return x; } set { x = Regex.Replace(value, @"[^0-9]+", new string("")); FunctionToUnknownX[CurrentFunctionRankName] = X; } }

        private string y;

        public string Y { get { return y; } set { y = Regex.Replace(value, @"[^0-9]+", new string("")); FunctionToUnknownY[CurrentFunctionRankName] = Y; } }

        private string coefficientA;

        public string CoefficientA { get { return coefficientA; } set { coefficientA = value; } }



        private string coefficientB;

        public string CoefficientB { get { return coefficientB; } set { coefficientB = value; } }

        private BindableCollection<int> coefficientCList;

        public BindableCollection<int> CoefficientCList 
        { 
            get { return coefficientCList; }

            set { coefficientCList = value; }
        }

        public int CurrentCoefficientC { get; set; }

        public double fXY 
        { 
            get
            {
                return Convert.ToInt32(CoefficientA) * Math.Pow(Convert.ToInt32(X), FunctionRank) + Convert.ToInt32(CoefficientB) * Math.Pow(Convert.ToInt32(Y), FunctionRank - 1) + CurrentCoefficientC;
            }
        }

        #region Dictionary
        private Dictionary<string, string> functionToCoefficientA = new Dictionary<string, string> { { "Linear", "1" }, { "Quadratic", "1" }, { "Cubic", "1" }, { "FourthDegree", "1" }, { "FifthDegree", "1" } };
        public Dictionary<string, string> FunctionToCoefficientA { get { return functionToCoefficientA; } set { functionToCoefficientA = value; } }

        private Dictionary<string, string> functionToCoefficientB = new Dictionary<string, string> { { "Linear", "1" }, { "Quadratic", "1" }, { "Cubic", "1" }, { "FourthDegree", "1" }, { "FifthDegree", "1" } };
        public Dictionary<string, string> FunctionToCoefficientB { get { return functionToCoefficientB; } set { functionToCoefficientB = value; } }


        private Dictionary<string, string> functionToUnknownX = new Dictionary<string, string> { { "Linear", "1" }, { "Quadratic", "1" }, { "Cubic", "1" }, { "FourthDegree", "1" }, { "FifthDegree", "1" } };
        public Dictionary<string, string> FunctionToUnknownX { get { return functionToUnknownX; } set { functionToUnknownX = value; } }

        private Dictionary<string, string> functionToUnknownY = new Dictionary<string, string> { { "Linear", "1" }, { "Quadratic", "1" }, { "Cubic", "1" }, { "FourthDegree", "1" }, { "FifthDegree", "1" } };
        public Dictionary<string, string> FunctionToUnknownY { get { return functionToUnknownY; } set { functionToUnknownY = value; } }


        private Dictionary<string, int> functionToCoefficientC = new Dictionary<string, int> { { "Linear", 0 }, { "Quadratic", 0 }, { "Cubic", 0 }, { "FourthDegree", 0 }, { "FifthDegree", 0 } };
        public Dictionary<string, int> FunctionToCoefficientC { get { return functionToCoefficientC; } set { functionToCoefficientC = value; } }

        #endregion
    }
}
