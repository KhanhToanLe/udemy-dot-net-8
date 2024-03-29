namespace XUnitTestProject
{
    public class UnitTest1
    {
        private readonly MyCaculator cal = new MyCaculator();

        [Fact]
        public void Test1()
        {
            // Arrange
            int y = 1; int x = 2;
            int expectedResult = 3;
            // Act
            int actualResult = cal.Add(x, y);
            //Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Test2()
        {
            // Arrange
            int x = 12; int y = 13;
            int expected = 25;

            // Act
            int actual = cal.Add(x, y);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}