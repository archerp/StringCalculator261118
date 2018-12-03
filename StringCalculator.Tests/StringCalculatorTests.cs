using System;
using NUnit.Framework;

namespace StringCalculator.Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        private static StringCalculator CreateCalc()
        {
            return new StringCalculator();
        }

        [Test] //1
        public void Add_EmptyString_ReturnsZero()
        {
            //Arrange
            var calc = CreateCalc();
            //Act
            var result = calc.Add("");
            //Assert
            Assert.AreEqual(0, result);
        }

        [Test] //2
        public void Add_SingleNumber_ReturnsNumber()
        {
            // Arrange
            var calc = CreateCalc();
            // Act
            var result = calc.Add("1");
            // Assert
            Assert.AreEqual(1, result);
        }

        [Test] //3
        public void Add_AddTwoNumbers_ReturnsSum()
        {
            // Arrange
            var calc = CreateCalc();
            // Act
            var result = calc.Add("1,2");
            // Assert
            Assert.AreEqual(3, result);
        }

        [TestCase("1,2,3", 6)] //4
        [TestCase("1,2,3,4", 10)]
        public void Add_MulitpleNumbers_ReturnsSum(string input, int answer)
        {
            // Arrange
            var calc = CreateCalc();
            // Act
            var result = calc.Add(input);
            // Assert
            Assert.AreEqual(answer, result);
        }

        [Test] //5
        public void Add_HandleNewLines_ReturnsSum()
        {
            // Arrange
            var calc = CreateCalc();
            // Act
            var result = calc.Add("1\n2,3");
            // Assert
            Assert.AreEqual(6, result);
        }

        [TestCase("//;\n1;2", 3)] //6
        [TestCase("//!\n1!2", 3)]
        public void Add_DifferentDelimiters_ReturnsSum(string input, int answer)
        {
            // Arrange
            var calc = CreateCalc();
            // Act
            var result = calc.Add(input);
            // Assert
            Assert.AreEqual(answer, result);
        }

        [TestCase("-1,2", "negative number was input : -1")] //7
        [TestCase("-1,-2", "negative number was input : -1,-2")]
        public void Add_NegativeNumbers_ThrowsException(string input, string errMsg)
        {
            // Arrange
            var calc = CreateCalc();
            // Act
            var e = Assert.Throws<Exception>(() => calc.Add(input));
            //Assert
            Assert.AreEqual(errMsg, e.Message);
        }

        [TestCase("2,1001", 2)] //8
        [TestCase("2002,1", 1)]
        public void Add_IgnoreNumbersGreaterThan1000_ReturnsSum(string input, int answer)
        {
            // Arrange
            var calc = CreateCalc();
            // Act
            var result = calc.Add(input);
            // Assert
            Assert.AreEqual(answer, result);
        }

        [TestCase("//[***]\n1***2***3",6)] //9
        [TestCase("//[!$%&&]\n1!$%&&40!$%&&50", 91)]
        public void Add_DelimiterOfAnyLength_ReturnsSum(string input, int answer)
        {
            // Arrange
            var calc = CreateCalc();
            // Act
            var result = calc.Add(input);
            // Assert
            Assert.AreEqual(answer, result);
        }

        [TestCase("///[*][%]\n1*2%3", 6)] //10
        [TestCase("///[!!][*%*][&&&&]\n1!!2*%*3&&&&4", 10)]
        public void Add_MultipleDelimiters_ReturnsSum(string input, int answer)
        {
            // Arrange
            var calc = CreateCalc();
            // Act
            var result = calc.Add(input);
            // Assert
            Assert.AreEqual(answer, result);
        }
    }
}
