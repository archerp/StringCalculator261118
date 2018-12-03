using System;
using NUnit.Framework;

namespace StringCalculator.Test
{
    [TestFixture]
    public class StringCalculatorTests
    {
        private static StringCalculator CreateStringCalc()
        {
            return new StringCalculator();
        }

        [Test] //1
        public void Add_EmptyString_ReturnsZero()
        {
            // Arrange
            var calc = CreateStringCalc();
            // Act
            var result = calc.Add("");
            // Assert
            Assert.AreEqual(0,result);
        }
    }
}
