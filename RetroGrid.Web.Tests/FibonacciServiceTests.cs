using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RetroGrid.Tests
{
    [TestClass()]
    public class FibonacciServiceTests
    {
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(5)]
        [DataRow(8)]
        [DataRow(17711)]
        [DataRow(39088169)]
        [DataTestMethod()]
        public void IsFibonacciNumberTest_ValidNumber_ReturnsTrue(int a)
        {
            // Arrange
            int number = a;

            // Act
            bool isFibonacciNumber = FibonacciService.IsFibonacciNumber(number);
            
            // Assert
            Assert.IsTrue(isFibonacciNumber);
        }

        [DataRow(0)]
        [DataRow(4)]
        [DataRow(6)]
        [DataRow(9)]
        [DataRow(54)]
        [DataRow(17712)]
        [DataRow(39088168)]
        [DataTestMethod()]
        public void IsFibonacciNumberTest_InvalidNumber_ReturnsFalse(int a)
        {
            // Arrange
            int number = a;

            // Act
            bool isFibonacciNumber = FibonacciService.IsFibonacciNumber(number);

            // Assert
            Assert.IsFalse(isFibonacciNumber);
        }
    }
}