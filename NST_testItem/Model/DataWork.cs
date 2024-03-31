using Caliburn.Micro;

namespace NST_testItem.Model
{
    /// <summary>
    /// Класс работы с данными модели
    /// </summary>
    public class DataWork
    {
        /// <summary>
        /// Функция получения списка моделей
        /// </summary>
        /// <param name="count">Количество моделей в списке, по умолчанию 1</param>
        /// <returns>Список моделей</returns>
        public List<FunctionModel> GetFunctionList(int count = 1)
        { 
            var output = new List<FunctionModel>();

            for (int i = 0; i < count; i++)
            {
                output.Add(GetFunction(i));
            }

            return output; 
        }
        /// <summary>
        /// Функция Добавления модели в список
        /// </summary>
        /// <param name="functionList">Список моделей</param>
        /// <param name="count">Количество моделей, которое необходимо добавить</param>
        /// <returns>Список моделей с добавленными данными</returns>
        public BindableCollection<FunctionModel> AddFunction(BindableCollection<FunctionModel> functionList, int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                functionList.Add(GetFunction(functionList.Count()));
            }

            return functionList;
        }
        /// <summary>
        /// Функция создания модели
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Экземпляр модели</returns>
        private FunctionModel GetFunction(int id)
        {
            var output = new FunctionModel();

            output.Id = id;
            output.FunctionRankNameList = new BindableCollection<string>();
            output.FunctionRankNameList.AddRange(["Linear", "Quadratic", "Cubic", "FourthDegree", "FifthDegree"]);
            output.CurrentFunctionRankName = output.FunctionRankNameList[0];
            output.X = "1";
            output.Y = "1";
            output.CoefficientA = "1";
            output.CoefficientB = "1";
            output.CoefficientCList = new BindableCollection<int> { Convert.ToInt32(1 * Math.Pow(10, output.FunctionRank - 1)),
                                                       Convert.ToInt32(2 * Math.Pow(10, output.FunctionRank - 1)),
                                                       Convert.ToInt32(3 * Math.Pow(10, output.FunctionRank - 1)),
                                                       Convert.ToInt32(4 * Math.Pow(10, output.FunctionRank - 1)),
                                                       Convert.ToInt32(5 * Math.Pow(10, output.FunctionRank - 1)) };
            output.CurrentCoefficientC = output.CoefficientCList[0];

            return output;
        }
        /// <summary>
        /// Функция для обновления списка коэффициентов c
        /// </summary>
        /// <param name="functionList">Список моделей</param>
        /// <param name="functionRank">Степень функции</param>
        /// <param name="index">Индекс модели в списке</param>
        /// <returns>Список моделей</returns>
        public BindableCollection<FunctionModel> UpdateCoeficientC(BindableCollection<FunctionModel> functionList, int functionRank, int index)
        {
            functionList[index].CoefficientCList = new BindableCollection<int> { Convert.ToInt32(1 * Math.Pow(10, functionRank - 1)),
                                                       Convert.ToInt32(2 * Math.Pow(10, functionRank - 1)),
                                                       Convert.ToInt32(3 * Math.Pow(10, functionRank - 1)),
                                                       Convert.ToInt32(4 * Math.Pow(10, functionRank - 1)),
                                                       Convert.ToInt32(5 * Math.Pow(10, functionRank - 1)) };
            return functionList;
        }
    }
}
