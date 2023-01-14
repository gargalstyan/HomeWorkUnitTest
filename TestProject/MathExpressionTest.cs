using ReflectionHomeWork;
namespace TestProject
{
    [TestClass]
    public class MathExpressionTest
    {
        [TestMethod]
        public void TestGetMethodName()
        {
            //Assign
            string correct = "Sqrt(100)";
            string incorrect = "Comeplex[]";
            MathExpressionSolver correctSolver = new MathExpressionSolver(correct);
            MathExpressionSolver incorrectSolver = new MathExpressionSolver(incorrect);

            //Act
            string correctMethodName = correctSolver.GetMethodName();
            //Assert
            Assert.AreEqual("Sqrt", correctMethodName);
            Assert.ThrowsException<ArgumentException>(() => incorrectSolver.GetMethodName());
        }
        [TestMethod]
        public void TestCalculate()
        {   //Assign
            string correct1 = "Sqrt(100)";
            string incorrect1 = "Sqrt(100,2)";
            string correct2 = "Log(8,2)";
            string incorrect2 = "Log(10,100,3)";
            MathExpressionSolver correctSolver1 = new MathExpressionSolver(correct1);
            MathExpressionSolver incorrectSolver1 = new MathExpressionSolver(incorrect1);
            MathExpressionSolver correctSolver2 = new MathExpressionSolver(correct2);
            MathExpressionSolver incorrectSolver2 = new MathExpressionSolver(incorrect2);
            //Act
            double correctResult1 = correctSolver1.Calculate();
            double correctResult2 = correctSolver2.Calculate();
            //Assert
            Assert.AreEqual(10, correctResult1);
            Assert.AreEqual(3, correctResult2);
            Assert.ThrowsException<ArgumentException>(() => incorrectSolver1.Calculate());
            Assert.ThrowsException<ArgumentException>(() => incorrectSolver2.Calculate());
        }
        [TestMethod]
        public void TestGetArgument()
        {
            //Assign
            string correct1 = "Sqrt(100)";
            string incorrect1 = "Sqrt100)";
            string correct2 = "Log(8,2)";
            string incorrect2 = "Log(2,8";
            MathExpressionSolver correctSolver1 = new MathExpressionSolver(correct1);
            MathExpressionSolver incorrectSolver1 = new MathExpressionSolver(incorrect1);
            MathExpressionSolver correctSolver2 = new MathExpressionSolver(correct2);
            MathExpressionSolver incorrectSolver2 = new MathExpressionSolver(incorrect2);
            //Act
            object[] argumentCorrect1 = correctSolver1.GetArguments();
            object[] argumentCorrect2 = correctSolver2.GetArguments();
            //Assert
            Assert.AreEqual(1, argumentCorrect1.Length);
            Assert.AreEqual(2, argumentCorrect2.Length);
            Assert.ThrowsException<ArgumentException>(() => incorrectSolver1.GetArguments());
            Assert.ThrowsException<ArgumentException>(() => incorrectSolver2.GetArguments());

        }
    }
}