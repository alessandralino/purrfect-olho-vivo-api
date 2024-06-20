namespace PurrfectOlhoVivo.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Add_ShouldReturnSumOfTwoNumbers()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.Add(2, 3);

            // Assert
            Assert.Equal(5, result);
        }

        public class Calculator
        {
            public int Add(int a, int b)
            {
                return a + b;
            }
        }
    }
}