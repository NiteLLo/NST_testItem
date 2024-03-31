using NST_testItem.Model;

namespace NST_testItem_Tests
{
    /// <summary>
    /// Класс модульного теста для проверки отдельных блоков решения
    /// </summary>
    public class FunctionCalculationTests
    {
        [Theory]
        [InlineData(0, "0", "0", "0", "0", 0)]
        [InlineData(10, "0", "0", "5", "5", 5)]
        [InlineData(0, "0", "0", "0", "0", 0)]
        [InlineData(0, "0", "0", "4", "0", 0)]
        [InlineData(8, "0", "0", "0", "8", 0)]
        [InlineData(3, "0", "0", "0", "0", 3)]
        [InlineData(11, "2", "0", "4", "0", 3)]
        [InlineData(5, "0", "5", "0", "2", 3)]
        [InlineData(21, "6", "4", "3", "0", 3)]
        [InlineData(28, "10", "5", "2", "3", 5)]
        public void LinearFunctionCalculationTest(double expected, string x, string y, string a, string b, int c)
        {
            var func = new FunctionModel();
            func.CurrentFunctionRankName = "Linear";
            func.X = x;
            func.Y = y;
            func.CoefficientA = a;
            func.CoefficientB = b;
            func.CurrentCoefficientC = c;

            Assert.Equal(expected, func.fXY);
        }

        [Theory]
        [InlineData(0, "0", "0", "0", "0", 0)]
        [InlineData(0, "5", "0", "0", "0", 0)]
        [InlineData(0, "0", "7", "0", "0", 0)]
        [InlineData(0, "0", "0", "4", "0", 0)]
        [InlineData(0, "0", "0", "0", "8", 0)]
        [InlineData(3, "0", "0", "0", "0", 3)]
        [InlineData(19, "2", "0", "4", "0", 3)]
        [InlineData(13, "0", "5", "0", "2", 3)]
        [InlineData(111, "6", "4", "3", "0", 3)]
        [InlineData(220, "10", "5", "2", "3", 5)]
        public void QuadraticFunctionCalculationTest(double expected, string x, string y, string a, string b, int c)
        {
            var func = new FunctionModel();
            func.CurrentFunctionRankName = "Quadratic";
            func.X = x;
            func.Y = y;
            func.CoefficientA = a;
            func.CoefficientB = b;
            func.CurrentCoefficientC = c;

            Assert.Equal(expected, func.fXY);
        }

        [Theory]
        [InlineData(0, "0", "0", "0", "0", 0)]
        [InlineData(0, "5", "0", "0", "0", 0)]
        [InlineData(0, "0", "7", "0", "0", 0)]
        [InlineData(0, "0", "0", "4", "0", 0)]
        [InlineData(0, "0", "0", "0", "8", 0)]
        [InlineData(3, "0", "0", "0", "0", 3)]
        [InlineData(35, "2", "0", "4","0", 3)]
        [InlineData(53, "0", "5", "0", "2", 3)]
        [InlineData(651, "6", "4", "3", "0", 3)]
        [InlineData(2080, "10", "5", "2", "3", 5)]
        public void CubicFunctionCalculationTest(double expected, string x, string y, string a, string b, int c)
        {
            var func = new FunctionModel();
            func.CurrentFunctionRankName = "Cubic";
            func.X = x;
            func.Y = y;
            func.CoefficientA = a;
            func.CoefficientB = b;
            func.CurrentCoefficientC = c;

            Assert.Equal(expected, func.fXY);
        }

        [Theory]
        [InlineData(0, "0", "0", "0", "0", 0)]
        [InlineData(0, "5", "0", "0", "0", 0)]
        [InlineData(0, "0", "7", "0", "0", 0)]
        [InlineData(0, "0", "0", "4", "0", 0)]
        [InlineData(0, "0", "0", "0", "8", 0)]
        [InlineData(3, "0", "0", "0", "0", 3)]
        [InlineData(67, "2", "0", "4", "0", 3)]
        [InlineData(253, "0", "5", "0", "2", 3)]
        [InlineData(3891, "6", "4", "3", "0", 3)]
        [InlineData(20380, "10", "5", "2", "3", 5)]
        public void FourthDegreeFunctionCalculationTest(double expected, string x, string y, string a, string b, int c)
        {
            var func = new FunctionModel();
            func.CurrentFunctionRankName = "FourthDegree";
            func.X = x;
            func.Y = y;
            func.CoefficientA = a;
            func.CoefficientB = b;
            func.CurrentCoefficientC = c;

            Assert.Equal(expected, func.fXY);
        }

        [Theory]
        [InlineData(0, "0", "0", "0", "0", 0)]
        [InlineData(0, "5", "0", "0", "0", 0)]
        [InlineData(0, "0", "7", "0", "0", 0)]
        [InlineData(0, "0", "0", "4", "0", 0)]
        [InlineData(0, "0", "0", "0", "8", 0)]
        [InlineData(3, "0", "0", "0", "0", 3)]
        [InlineData(131, "2", "0", "4", "0", 3)]
        [InlineData(1253, "0", "5", "0", "2", 3)]
        [InlineData(23331, "6", "4", "3", "0", 3)]
        [InlineData(201880, "10", "5", "2", "3", 5)]
        public void FifthDegreeFunctionCalculationTest(double expected, string x, string y, string a, string b, int c)
        {
            var func = new FunctionModel();
            func.CurrentFunctionRankName = "FifthDegree";
            func.X = x;
            func.Y = y;
            func.CoefficientA = a;
            func.CoefficientB = b;
            func.CurrentCoefficientC = c;

            Assert.Equal(expected, func.fXY);
        }
    }
}