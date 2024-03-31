namespace NST_testItem.Model
{
    /// <summary>
    /// Класс конвертера для перевода специфичных значений степени математической функции в её порядок в числовом значении и наоборот
    /// </summary>
    public class ConvertFunctionRankNameToFunctionRank
    {
        /// <summary>
        /// Функция конвертации значения
        /// </summary>
        /// <param name="value">Свовесное обозначение степени математической функции</param>
        /// <returns>Числовое значение степени математической функции</returns>
        public int Convert(string value)
        {
            switch (value) 
            {
                case "Linear": return 1;
                case "Quadratic": return 2;
                case "Cubic": return 3;
                case "FourthDegree": return 4;
                case "FifthDegree": return 5;
                
                default: return 1;
            }
        }
        /// <summary>
        /// Функция обратной конвертации значения
        /// </summary>
        /// <param name="value">Числовое значение степени математической функции</param>
        /// <returns>Свовесное обозначение степени математической функции</returns>
        public string ConvertBack(int value)
        {
            switch (value)
            {
                case 1: return "Linear";
                case 2: return "Quadratic";
                case 3: return "Cubic";
                case 4: return "FourthDegree";
                case 5: return "FifthDegree";

                default: return "Linear";
            }
        }
    }
}
